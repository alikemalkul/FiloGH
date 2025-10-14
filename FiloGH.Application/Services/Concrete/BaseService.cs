using FiloGH.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloGH.Core.Services
{
    /// <summary>
    /// Tüm Servis sınıflarının miras alacağı temel sınıf.
    /// Ortak CRUD operasyonlarını ve Unit of Work yönetimini sağlar.
    /// </summary>
    /// <typeparam name="T">Servisin çalıştığı Entity tipi.</typeparam>
    /// <typeparam name="TId">Entity'nin anahtar (ID) tipi.</typeparam>
    public abstract class BaseService<T, TId> : IDisposable
        where T : class, IEntity<TId>
        where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId> // TId kısıtları eklendi
    {
        // Protected alanlar, miras alan sınıflar tarafından erişilebilir olmalıdır.
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IGenericRepository<T, TId> Repository;

        /// <summary>
        /// Constructor. Unit of Work bağımlılığını enjekte eder ve Repository'yi başlatır.
        /// </summary>
        /// <param name="unitOfWork">Veritabanı işlemleri için Unit of Work örneği.</param>
        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            // Unit of Work üzerinden ilgili Entity için Repository'yi al.
            Repository = unitOfWork.GetRepository<T, TId>();
        }

        // ----------------------------------------------------
        // Temel CRUD Metotları
        // ----------------------------------------------------

        /// <summary>
        /// Entity'yi ID'sine göre asenkron olarak getirir.
        /// asNoTracking yerine Repository'ye uyumlu olarak disableTracking kullanıldı.
        /// </summary>
        public virtual async Task<T?> GetByIdAsync(TId id, bool disableTracking = false)
        {
            // Repository'deki metoda uyum için asNoTracking -> disableTracking olarak değiştirildi.
            return await Repository.GetByIdAsync(id, disableTracking);
        }

        /// <summary>
        /// Tüm Entity'leri getirir.
        /// </summary>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        /// <summary>
        /// Yeni bir Entity ekler ve değişikliği kaydeder.
        /// </summary>
        public virtual async Task<T> AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
            // CommitAsync -> SaveAsync olarak değiştirildi.
            await UnitOfWork.SaveAsync();
            return entity;
        }

        /// <summary>
        /// Mevcut bir Entity'i günceller ve değişikliği kaydeder.
        /// Repository'deki senkron (void) metoda uyum sağlandı.
        /// </summary>
        public virtual async Task UpdateAsync(T entity)
        {
            // Repository'deki senkron metot çağrıldı.
            Repository.Update(entity);
            // CommitAsync -> SaveAsync olarak değiştirildi.
            await UnitOfWork.SaveAsync();
        }

        /// <summary>
        /// ID'ye göre Entity'i siler ve değişikliği kaydeder.
        /// </summary>
        public virtual async Task DeleteAsync(TId id)
        {
            await Repository.DeleteAsync(id);
            // CommitAsync -> SaveAsync olarak değiştirildi.
            await UnitOfWork.SaveAsync();
        }

        // ----------------------------------------------------
        // IDisposable Uygulaması
        // ----------------------------------------------------

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // UnitOfWork IDisposable olduğu için burada serbest bırakılır.
                    UnitOfWork.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
