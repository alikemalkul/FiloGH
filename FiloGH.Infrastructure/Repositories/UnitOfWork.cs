using FiloGH.Application.Interfaces;
using FiloGH.Core.Interfaces; // IUnitOfWork, IGenericRepository ve IEntity için
using FiloGH.Infrastructure.Data.Contexts; // AppDbContext için
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloGH.Infrastructure.Repositories
{
    /// <summary>
    /// Unit of Work (İş Birimi) deseni uygulaması.
    /// Tüm Repository'lerin tek bir veritabanı bağlamını (AppDbContext) kullanmasını sağlar
    /// ve tüm işlemlerin tek bir atomik birim olarak kaydedilmesini (Save) yönetir.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }

        /// <summary>
        /// Belirtilen Entity ve ID tipine göre ilgili Generic Repository'yi döndürür.
        /// </summary>
        public IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>()
            where TEntity : class, IEntity<TId>
            // Repository ve Service katmanları arasındaki tutarlılığı sağlamak için TId kısıtlamaları eklendi.
            where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
        {
            var typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                // GenericRepository'nin aynı namespace'te veya uygun bir using ile erişilebilir olduğu varsayılır.
                var repositoryInstance = new GenericRepository<TEntity, TId>(_context);
                _repositories.Add(typeName, repositoryInstance);
            }

            return (IGenericRepository<TEntity, TId>)_repositories[typeName];
        }

        /// <summary>
        /// Bekleyen tüm değişiklikleri veritabanına asenkron olarak kaydeder (IUnitOfWork.SaveAsync implementasyonu).
        /// HATA GİDERME: CommitAsync metodu SaveAsync olarak yeniden adlandırıldı.
        /// </summary>
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Veritabanı Kaydetme Hatası: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Bekleyen tüm değişiklikleri veritabanına senkron olarak kaydeder (IUnitOfWork.Save implementasyonu).
        /// </summary>
        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Veritabanı Kaydetme Hatası: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
