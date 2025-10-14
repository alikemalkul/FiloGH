using Microsoft.EntityFrameworkCore;

namespace FiloGH.Core.Interfaces
{
    // EF Core DbContext için temel arayüz.
    // UnitOfWork ve Repository'ler bu arayüzü kullanarak Context'e erişir.
    public interface IApplicationDbContext : IDisposable
    {
        // DbSet'lere erişim sağlayan metot
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        // Değişiklikleri kaydetme metodu (IUnitOfWork tarafından kullanılır)
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        // EF Core Entry'sine erişim için gerekli (Update metodu için)
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
