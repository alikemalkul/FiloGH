using FiloGH.Application.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FiloGH.Application.Services
{
    /// <summary>
    /// Currency (Para Birimi) varlığını yöneten servis.
    /// ID tipi byte olduğu için IGenericRepository<Currency, byte> kullanır.
    /// </summary>
    public class CurrencyService : ICurrencyService
    {
        // IUnitOfWork artık SaveAsync metodunu içeriyor.
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<Currency, byte> _currencyRepository;

        public CurrencyService(IUnitOfWork uow)
        {
            _uow = uow;
            _currencyRepository = _uow.GetRepository<Currency, byte>();
        }

        // -------------------------------------------------------------------
        // OKUMA (READ) METOTLARI
        // -------------------------------------------------------------------

        /// <summary>
        /// Belirtilen ID'ye göre tekil Para Birimini çeker.
        /// </summary>
        public async Task<Currency?> GetByIdAsync(byte id, string? includeProperties = null)
        {
            // CS1739 Hatası Çözüldü: Repository imzamızla uyumlu olması için 
            // 'asNoTracking' yerine 'disableTracking' kullanıldı.
            return await _currencyRepository.GetByIdAsync(
                id,
                disableTracking: false, // İzleme açık
                includeProperties: includeProperties
            );
        }

        /// <summary>
        /// Para Birimi listesini filtreleme, sıralama ve ilişkili verileri yükleme seçenekleriyle çeker.
        /// </summary>
        public async Task<IEnumerable<Currency>> GetAllAsync(
            Expression<Func<Currency, bool>>? filter = null,
            Func<IQueryable<Currency>, IOrderedQueryable<Currency>>? orderBy = null,
            Func<IQueryable<Currency>, IIncludableQueryable<Currency, object>>? include = null,
            bool asNoTracking = true)
        {
            // CS1061 Hatası Çözüldü: Repository'deki GetAll metodu yerine 
            // doğru asenkron metot olan 'GetAllAsync' kullanıldı ve beklenildi (await).
            var result = await _currencyRepository.GetAllAsync(
                filter: filter,
                orderBy: orderBy,
                include: include,
                disableTracking: asNoTracking // Parametre adı düzeltildi.
            );

            // Eğer sıralama (orderBy) verilmemişse, client tarafında Ada göre sırala.
            if (orderBy == null)
            {
                result = result.OrderBy(c => c.Name);
            }

            return result;
        }

        // -------------------------------------------------------------------
        // YAZMA (WRITE) METOTLARI
        // -------------------------------------------------------------------

        /// <summary>
        /// Yeni bir Para Birimi ekler.
        /// </summary>
        public async Task AddAsync(Currency entity)
        {
            await _currencyRepository.AddAsync(entity);
            // CS1061 Hatası Çözüldü: CommitAsync yerine kararlaştırılan 'SaveAsync' kullanıldı.
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Mevcut bir Para Birimini günceller (Fetch/Update Pattern).
        /// </summary>
        public async Task UpdateAsync(Currency entity)
        {
            // Güncelleme için izleme açık (disableTracking: false) Entity'yi çekiyoruz.
            var existingEntity = await _currencyRepository.GetByIdAsync(
                entity.Id,
                disableTracking: false // CS1739 Hatası Çözüldü: disableTracking kullanıldı.
            );

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Currency with ID {entity.Id} not found.");
            }

            // Güncel verileri var olan entity üzerine kopyala.
            // Bu yöntemle sadece gerekli alanların güncellendiği EF Core tarafından algılanır.
            existingEntity.Name = entity.Name;
            existingEntity.Code = entity.Code;
            existingEntity.Symbol = entity.Symbol;
            existingEntity.IsActive = entity.IsActive;
            existingEntity.Type = entity.Type;
            existingEntity.IsSystemDefault = entity.IsSystemDefault;
            existingEntity.IsRateTracked = entity.IsRateTracked;

            // Update metoduna gerek kalmadan SaveAsync çağrılabilir, ancak UpdateAsync 
            // metodunun çağrılması EF Core'a durumun değiştiğini açıkça bildirmenin bir yoludur.
            await _currencyRepository.UpdateAsync(existingEntity);

            // CS1061 Hatası Çözüldü: CommitAsync yerine kararlaştırılan 'SaveAsync' kullanıldı.
            await _uow.SaveAsync();
        }

        /// <summary>
        /// Belirtilen ID'ye sahip Para Birimini siler.
        /// </summary>
        public async Task DeleteAsync(byte id)
        {
            // Silinecek varlığı izleme açık (disableTracking: false) olarak çekiyoruz.
            // CS1739 Hatası Çözüldü: 'asNoTracking' yerine 'disableTracking' kullanıldı.
            var entity = await _currencyRepository.GetByIdAsync(id, disableTracking: false);

            if (entity != null)
            {
                // Repository'nin asenkron Delete metodunu çağırıyoruz.
                await _currencyRepository.DeleteAsync(entity);

                // CS1061 Hatası Çözüldü: CommitAsync yerine kararlaştırılan 'SaveAsync' kullanıldı.
                await _uow.SaveAsync();
            }
        }
    }
}
