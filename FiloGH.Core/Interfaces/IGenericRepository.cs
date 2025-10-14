using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FiloGH.Core.Interfaces
{
    // TEntity'nin IEntity<TId>'den kalıtım alması ve TId'nin uygun bir değer tipi olması zorunludur.
    public interface IGenericRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        // -------------------------------------------------------------------
        // OKUMA METOTLARI (READ)
        // -------------------------------------------------------------------

        /// <summary>
        /// Belirtilen ID'ye göre tekil bir varlığı asenkron olarak çeker.
        /// </summary>
        Task<TEntity?> GetByIdAsync(TId id, bool disableTracking = true, string? includeProperties = null);

        /// <summary>
        /// Tüm varlıkları varsayılan ayarlarla asenkron olarak çeker.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gelişmiş filtreleme ve sıralama seçenekleriyle varlık listesini asenkron olarak çeker.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync(
      Expression<Func<TEntity, bool>>? filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
      bool disableTracking = true);

        // -------------------------------------------------------------------
        // YAZMA/GÜNCELLEME/SİLME METOTLARI (WRITE)
        // -------------------------------------------------------------------

        /// <summary>
        /// Yeni bir varlık ekler (Değişiklikleri kaydetmez). Service katmanındaki AddAsync metoduna uyması için asenkron yapıldı.
        /// </summary>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Mevcut bir varlığı senkron olarak günceller (Değişiklikleri kaydetmez).
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Mevcut bir varlığı asenkron olarak günceller (Değişiklikleri kaydetmez).
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Belirtilen varlığı senkron olarak siler (Değişiklikleri kaydetmez).
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        /// Belirtilen varlığı asenkron olarak siler (Değişiklikleri kaydetmez).
        /// </summary>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Belirtilen ID'ye sahip varlığı bulur ve asenkron olarak siler (Değişiklikleri kaydetmez).
        /// </summary>
        Task DeleteAsync(TId id);
    }
}
