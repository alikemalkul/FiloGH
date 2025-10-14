using FiloGH.Application.Services.Abstract;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// Servisi Application katmanına taşıyoruz.
namespace FiloGH.Application.Services.Concrete
{
    /// <summary>
    /// Ölçü Birimi (UnitOfMeasure) varlığını yöneten servis. 
    /// IUnitOfMeasureService (ve dolayısıyla IBaseService) arayüzlerini uygular.
    /// </summary>
    public class UnitOfMeasureService : IUnitOfMeasureService // IUnitOfMeasureService, IBaseService'den kalıtım almalı
    {
        // Repository'nin Generic TId (byte) desteği için imzası güncellendi.
        private readonly IGenericRepository<UnitOfMeasure, byte> _uomRepository;
        private readonly IUnitOfWork _uow;

        public UnitOfMeasureService(IUnitOfWork uow)
        {
            _uow = uow;
            // UnitOfWork'ten UnitOfMeasure için byte ID'li Repository alınıyor.
            _uomRepository = _uow.GetRepository<UnitOfMeasure, byte>();
        }

        // -------------------------------------------------------------------
        // OKUMA (READ) METOTLARI (IBaseService Uygulaması)
        // -------------------------------------------------------------------

        /// <summary>
        /// Belirtilen ID'ye sahip Ölçü Birimini (UnitOfMeasure) ilişkili verilerle çeker.
        /// IBaseService'in tam imzasını uygular: GetByIdAsync(byte id, string? includeProperties).
        /// HATA DÜZELTİLDİ: 'GetByIdAsync' does not implement interface member
        /// </summary>
        /// <param name="id">Ölçü Birimi ID'si.</param>
        /// <param name="includeProperties">Dahil edilecek ilişkili varlıkların virgülle ayrılmış listesi.</param>
        public async Task<UnitOfMeasure?> GetByIdAsync(byte id, string? includeProperties = null)
        {
            // Repository'nin GetByIdAsync metodu kullanılarak entity çekilir.
            // disableTracking: false yapıldı, çünkü bu kayıt güncelleme için çekilebilir.
            return await _uomRepository.GetByIdAsync(id, disableTracking: false, includeProperties: includeProperties);
        }

        /// <summary>
        /// Kapsamlı filtreleme, sıralama ve ilişkili veri yükleme seçenekleriyle tüm kayıtları çeker.
        /// HATA DÜZELTİLDİ: 'GetAll' yerine Repository'nin 'GetAllAsync' metodu kullanıldı.
        /// </summary>
        public async Task<IEnumerable<UnitOfMeasure>> GetAllAsync(
            Expression<Func<UnitOfMeasure, bool>>? filter = null,
            Func<IQueryable<UnitOfMeasure>, IOrderedQueryable<UnitOfMeasure>>? orderBy = null,
            Func<IQueryable<UnitOfMeasure>, IIncludableQueryable<UnitOfMeasure, object>>? include = null,
            bool disableTracking = true) // Parametre ismi asNoTracking -> disableTracking olarak değiştirildi
        {
            // Varsayılan olarak UomType ve BaseUnit'i dahil et
            Func<IQueryable<UnitOfMeasure>, IIncludableQueryable<UnitOfMeasure, object>> defaultInclude = source =>
                 source.Include(u => u.UomType!).Include(u => u.BaseUnit!);

            // Eğer include parametresi boş gelirse varsayılan include'ı kullan.
            // Repository'nin GetAllAsync metodu çağrıldı.
            var entities = await _uomRepository.GetAllAsync(
                filter,
                orderBy,
                include ?? defaultInclude,
                disableTracking);

            // Eğer orderBy gelmediyse, adı baz alarak bellek içi sıralama yapılır.
            // Not: Repository'deki GetAllAsync, sıralanmış sonucu dönüyor olmalıdır.
            // Ancak, IQueryable'dan IEnumerable'a geçtiğimiz için son sıralama burada yapılabilir.
            if (orderBy == null)
            {
                return entities.OrderBy(u => u.Name).ToList();
            }

            return entities;
        }

        // -------------------------------------------------------------------
        // YAZMA (WRITE) METOTLARI (IBaseService Uygulaması)
        // -------------------------------------------------------------------

        /// <summary>
        /// Yeni bir Ölçü Birimi ekler ve değişiklikleri kaydeder.
        /// </summary>
        public async Task AddAsync(UnitOfMeasure uom)
        {
            // KRİTİK TEMİZLİK: Navigasyon property'leri sıfırlandı.
            if (uom.UomType != null && uom.UomTypeId != 0)
            {
                uom.UomType = null!;
            }
            if (uom.BaseUnit != null && uom.BaseUnitId.HasValue)
            {
                uom.BaseUnit = null;
            }

            await _uomRepository.AddAsync(uom);
            // HATA DÜZELTİLDİ: CommitAsync yerine SaveAsync kullanıldı.
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Mevcut bir Ölçü Birimini günceller (Fetch/Update Pattern).
        /// </summary>
        public async Task UpdateAsync(UnitOfMeasure uom)
        {
            // 1. Veritabanından mevcut ve İZLENEN (tracked) entity'yi çek
            var existingUoM = await _uomRepository.GetByIdAsync(uom.Id, disableTracking: false);

            if (existingUoM == null)
            {
                throw new KeyNotFoundException($"UnitOfMeasure with ID {uom.Id} not found.");
            }

            // 2. UI'dan gelen entity'deki skalar değerleri izlenen entity'ye kopyala.
            existingUoM.Name = uom.Name;
            existingUoM.Code = uom.Code;
            existingUoM.ConversionFactor = uom.ConversionFactor;
            existingUoM.DecimalPlaces = uom.DecimalPlaces;
            existingUoM.IsActive = uom.IsActive;
            existingUoM.UomTypeId = uom.UomTypeId;
            existingUoM.BaseUnitId = uom.BaseUnitId;

            // 3. Değişiklikleri kaydet.
            // HATA DÜZELTİLDİ: CommitAsync yerine SaveAsync kullanıldı.
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye sahip Ölçü Birimini siler.
        /// </summary>
        public async Task DeleteAsync(byte id)
        {
            // Repository'nin DeleteAsync metodu doğrudan kullanılarak silme işlemi yapılır.
            await _uomRepository.DeleteAsync(id);

            // HATA DÜZELTİLDİ: CommitAsync yerine SaveAsync kullanıldı.
            // HATA DÜZELTİLDİ: Repository'nin DeleteAsync(id) metodu kullanıldığı için 
            // karışıklığa neden olan Remove(uom) çağrısı kaldırıldı.
            await _uow.SaveAsync();
        }

        // Not: Eğer UnitOfMeasure'ın silmeden önce kontrol edilmesi gerekiyorsa,
        // _uomRepository.GetByIdAsync(id, disableTracking: true) ile kontrol yapılıp
        // ardından DeleteAsync(id) çağrılabilir.
    }
}
