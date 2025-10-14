using FiloGH.Core.Interfaces;
using FiloGH.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace FiloGH.Infrastructure.Repositories
{
    /// <summary>
    /// Tüm Entity'ler için temel CRUD işlemlerini sağlayan somut Repository sınıfı.
    /// IGenericRepository arayüzünü (sözleşmesini) uygular.
    /// </summary>
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
        where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context) // Constructor
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // -------------------------------------------------------------------
        // ASENKRON OKUMA METOTLARI
        // -------------------------------------------------------------------

        public async Task<TEntity?> GetByIdAsync(TId id, bool disableTracking = true, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, "Id");
            var constant = Expression.Constant(id);
            var body = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return await query.FirstOrDefaultAsync(lambda);
        }

        /// <summary>
        /// IGenericRepository'nin parametreli GetAllAsync implementasyonu.
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        // --- HATA DÜZELTME 1: Eksik parametresiz GetAllAsync eklendi ---
        /// <summary>
        /// IGenericRepository'nin beklediği parametresiz GetAllAsync implementasyonu.
        /// Parametreli versiyonu çağırır.
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // Parametresiz çağrıldığında, tüm kayıtları varsayılan ayarlarla çeker.
            return await GetAllAsync(filter: null, orderBy: null, include: null, disableTracking: true);
        }


        // -------------------------------------------------------------------
        // YAZMA/GÜNCELLEME/SİLME METOTLARI (Senkron ve Asenkron)
        // -------------------------------------------------------------------

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            // Not: SaveChangesAsync IUnitOfWork tarafından çağrılmalıdır.
        }

        // --- HATA DÜZELTME 2: Eksik senkron Update(TEntity) eklendi ---
        /// <summary>
        /// IGenericRepository'nin beklediği senkron Update(TEntity) implementasyonu.
        /// </summary>
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Asenkron Update (Senkron işlemi Task'a sarar).
        /// </summary>
        public Task UpdateAsync(TEntity entity)
        {
            // Senkron metodu çağırır ve Task.CompletedTask döner.
            Update(entity);
            return Task.CompletedTask;
        }

        // --- HATA DÜZELTME 3: Eksik senkron Delete(TEntity) eklendi ---
        /// <summary>
        /// IGenericRepository'nin beklediği senkron Delete(TEntity) implementasyonu.
        /// </summary>
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Asenkron Delete (Senkron işlemi Task'a sarar).
        /// </summary>
        public Task DeleteAsync(TEntity entity)
        {
            // Senkron metodu çağırır ve Task.CompletedTask döner.
            Delete(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(TId id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                // FindAsync zaten tracking yapıyor, bu yüzden direkt Remove kullanılabilir.
                _dbSet.Remove(entityToDelete);
            }
        }
    }
}
