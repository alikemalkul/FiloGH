using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FiloGH.Application.Services.Abstract
{
    /// <summary>
    /// Tüm iş servisleri için temel CRUD ve sorgulama metotlarını tanımlar.
    /// Repository katmanındaki IGenericRepository'nin servis katmanı karşılığıdır.
    /// </summary>
    /// <typeparam name="TEntity">İşlem görecek Entity tipi.</typeparam>
    /// <typeparam name="TId">Entity'nin anahtar tipi.</typeparam>
    public interface IBaseService<TEntity, TId>
        // KRİTİK DÜZELTME: TId kısıtlaması IEntity'deki kısıtlamalarla eşleşmelidir.
        where TEntity : class, IEntity<TId>
        where TId : struct, System.IComparable, System.IConvertible, System.IComparable<TId>, System.IEquatable<TId>
    {
        // -------------------------------------------------------------------
        // OKUMA (READ) METOTLARI
        // -------------------------------------------------------------------

        /// <summary>
        /// Entity listesini filtreleme, sıralama ve ilişkili verileri yükleme seçenekleriyle çeker.
        /// </summary>
        /// <param name="filter">Filtreleme koşulu (Lambda ifadesi).</param>
        /// <param name="orderBy">Sıralama kuralı.</param>
        /// <param name="include">Yüklenecek ilişkili varlıklar (Func<...IIncludableQueryable...> formatında).</param>
        /// <param name="asNoTracking">True ise veritabanı izlemesi devre dışı bırakılır (performans için önerilir).</param>
        /// <returns>TEntity entity'lerinden oluşan bir koleksiyon.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool asNoTracking = true
        );

        /// <summary>
        /// Belirtilen ID'ye göre tekil Entity'yi çeker.
        /// </summary>
        Task<TEntity?> GetByIdAsync(TId id, string? includeProperties = null);

        // -------------------------------------------------------------------
        // YAZMA (WRITE) METOTLARI
        // -------------------------------------------------------------------

        /// <summary>
        /// Yeni bir Entity ekler ve UnitOfWork'ü kaydeder.
        /// </summary>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Mevcut bir Entity'yi günceller (Fetch/Update Pattern kullanılması önerilir).
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Belirtilen ID'ye sahip Entity'yi siler ve UnitOfWork'ü kaydeder.
        /// </summary>
        Task DeleteAsync(TId id);
    }
}
