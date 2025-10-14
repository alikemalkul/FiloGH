namespace FiloGH.Core.Interfaces
{
    /// <summary>
    /// Unit of Work (İş Birimi) deseninin arayüzüdür. 
    /// Veritabanı işlemlerini tek bir atomik transaction altında toplar ve tüm repository'lere erişim sağlar.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Belirtilen Entity ve ID tipine göre ilgili Generic Repository'yi döndürür.
        /// </summary>
        IGenericRepository<TEntity, TId> GetRepository<TEntity, TId>()
            where TEntity : class, IEntity<TId>
            // KRİTİK EŞLEŞME NOKTASI
            where TId : struct, IComparable, IConvertible, IComparable<TId>, IEquatable<TId>;

        /// <summary>
        /// Context'teki tüm bekleyen değişiklikleri (Add, Update, Delete) veritabanına asenkron olarak kaydeder.
        /// EF Core'daki SaveChangesAsync() metodunu sarmalar. Kaydedilen kayıt sayısını döndürür.
        /// </summary>
        Task<int> SaveAsync();

        /// <summary>
        /// Context'teki tüm bekleyen değişiklikleri (Add, Update, Delete) veritabanına senkron olarak kaydeder.
        /// EF Core'daki SaveChanges() metodunu sarmalar. Kaydedilen kayıt sayısını döndürür.
        /// </summary>
        int Save();
    }
}
