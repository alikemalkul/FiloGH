using FiloGH.Application.Services.Abstract;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces; // IBaseService'in burada olduğunu varsayıyoruz
using FiloGH.Core.Services;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace FiloGH.Application.Services.Concrete
{
    /// <summary>
    /// Ölçü Birimi Tipleri (UomType) için CRUD ve sorgulama işlemlerini yönetir.
    /// BaseService'i miras alır ve IUomTypeService sözleşmesini uygular.
    /// </summary>
    public class UomTypeService : BaseService<UomType, byte>, IUomTypeService
    {
        // Constructor, BaseService'in constructor'ını çağırır.
        public UomTypeService(IUnitOfWork uow) : base(uow)
        {
        }

        // -------------------------------------------------------------------
        // YAZMA (WRITE) METOTLARI (IBaseService/BaseService Uygulaması)
        // -------------------------------------------------------------------

        /// <summary>
        /// 1. BaseService kontratını uygular (override). Task<TEntity> döndürmek zorundadır.
        /// </summary>
        public override async Task<UomType> AddAsync(UomType entity)
        {
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveAsync();
            // BaseService'in beklediği entity'yi döndürüyoruz.
            return entity;
        }

        /// <summary>
        /// 2. IBaseService kontratını uygular (explicit implementation). Task döndürmek zorundadır.
        /// </summary>
        async Task IBaseService<UomType, byte>.AddAsync(UomType entity)
        {
            // Basitçe Task<UomType> döndüren override metodumuzu çağırıyoruz
            // ve dönüş değerini (UomType) yok sayarak IBaseService'in beklediği
            // Task (void) kontratını sağlıyoruz.
            await this.AddAsync(entity);
        }


        /// <summary>
        /// Mevcut bir Ölçü Birimi Tipini günceller.
        /// Repository'nin senkron 'Update(TEntity)' metodu kullanıldı.
        /// </summary>
        public override async Task UpdateAsync(UomType entity)
        {
            // Repository'nin senkron Update metodunu çağırıyoruz.
            Repository.Update(entity);
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye sahip Ölçü Birimi Tipini siler.
        /// Repository'nin doğrudan ID ile silme metodu kullanıldı.
        /// </summary>
        public override async Task DeleteAsync(byte id)
        {
            // Repository'nin asenkron DeleteAsync(TId id) metodunu kullanıyoruz.
            await Repository.DeleteAsync(id);
            await UnitOfWork.SaveAsync();
        }

        // -------------------------------------------------------------------
        // OKUMA (READ) METOTLARI (IBaseService/IUomTypeService Uygulaması)
        // -------------------------------------------------------------------

        /// <summary>
        /// Kapsamlı filtreleme, sıralama ve ilişkili veri yükleme seçenekleriyle tüm kayıtları çeker.
        /// Gerekli olmadığı için 'new' anahtar kelimesi kaldırıldı. (CS0109 Düzeltildi)
        /// </summary>
        public async Task<IEnumerable<UomType>> GetAllAsync( // <<< 'new' kaldırıldı
            Expression<Func<UomType, bool>>? filter = null,
            Func<IQueryable<UomType>, IOrderedQueryable<UomType>>? orderBy = null,
            Func<IQueryable<UomType>, IIncludableQueryable<UomType, object>>? include = null,
            bool disableTracking = true)
        {
            // Repository'nin karmaşık filtreleme/sıralama işini yapan GetAllAsync metodunu çağırıyoruz.
            return await Repository.GetAllAsync(filter, orderBy, include, disableTracking);
        }

        /// <summary>
        /// Entity'yi ID'sine göre asenkron olarak getirir.
        /// Gerekli olmadığı için 'new' anahtar kelimesi kaldırıldı.
        /// </summary>
        public async Task<UomType?> GetByIdAsync(byte id, string? includeProperties = null) // <<< 'new' kaldırıldı
        {
            // Repository'deki GetByIdAsync metodu çağrıldı. Tracking kapatılmadı (false).
            return await Repository.GetByIdAsync(id, disableTracking: false, includeProperties: includeProperties);
        }

        // -------------------------------------------------------------------
        // IUomTypeService'e Özel Metot
        // -------------------------------------------------------------------

        public async Task<IEnumerable<UomType>> GetUomTypesByNameOrderedAsync()
        {
            // Repository'nin parametresiz GetAllAsync metodunu çağırıp sonucu bellekte sıralıyoruz.
            var list = await Repository.GetAllAsync();

            // Veritabanı sorgusu değil, bellek içi sıralama (OrderBy) yapılıyor.
            return list.OrderBy(t => t.Name).ToList();
        }
    }
}
