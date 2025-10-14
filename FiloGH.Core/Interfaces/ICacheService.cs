namespace FiloGH.Core.Interfaces
{
    /// <summary>
    /// Statik ve sık kullanılan verileri önbelleğe almak için jenerik arayüz.
    /// Tüm önbellek servisleri bu arayüzden türetilecektir (Örn: ICurrencyCacheService).
    /// </summary>
    /// <typeparam name="TEntity">Önbelleğe alınacak entity tipi.</typeparam>
    public interface ICacheService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Önbelleğe alınmış verilerin listesi (Thread-safe erişim gerektirir).
        /// </summary>
        List<TEntity> Items { get; }

        /// <summary>
        /// Önbellek verisini dışarıdan alınan bir liste ile ayarlar.
        /// Bu, genellikle sistem başlangıcında veya harici bir kaynaktan yüklemede kullanılır.
        /// </summary>
        /// <param name="items">Önbelleğe yüklenecek entity listesi.</param>
        Task SetItemsAsync(List<TEntity> items);

        /// <summary>
        /// Veri kaynağını (örneğin Repository) kullanarak önbelleği manuel olarak yeniler.
        /// </summary>
        /// <param name="dataLoader">Yeni veriyi veritabanından çekecek asenkron fonksiyon.</param>
        Task ReloadFromSourceAsync(Func<Task<List<TEntity>>> dataLoader);
    }
}
