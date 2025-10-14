using FiloGH.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FiloGH.Infrastructure.Services.Cache
{
    /// <summary>
    /// Uygulama genelinde statik ve sık değişmeyen verileri (Örn: Branch, Currency, UomType)
    /// önbellekte tutan ve yöneten hizmet.
    /// Singleton olarak kaydedilmelidir.
    /// </summary>
    /// <typeparam name="TEntity">Önbelleğe alınacak entity tipi.</typeparam>
    public class CacheService<TEntity> : ICacheService<TEntity> where TEntity : class
    {
        // Items listesine eş zamanlı erişimleri yönetmek için kilitleme nesnesi.
        private readonly object _lock = new object();

        // Önbellekte tutulan veriler. Sadece SetItemsAsync metodu ile değiştirilebilir.
        public List<TEntity> Items { get; private set; } = new List<TEntity>();

        public CacheService()
        {
            // Bu hizmet, DbContext veya Repository bağımlılığı olmaksızın çalışır.
        }

        /// <summary>
        /// Önbellek listesinin içeriğini thread-safe olarak günceller/kurar.
        /// Genellikle CacheInitializer tarafından kullanılır.
        /// </summary>
        /// <param name="items">Yeni önbellek verileri.</param>
        public Task SetItemsAsync(List<TEntity> items)
        {
            lock (_lock)
            {
                // Mevcut listeyi gelen yeni liste ile değiştirir.
                Items = items;
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Harici bir veri yükleyici fonksiyonu (dataLoader) kullanarak önbelleği yeniden yükler.
        /// </summary>
        /// <param name="dataLoader">Veriyi çekmekten sorumlu asenkron fonksiyon (Örn: Repository'den veri çekme).</param>
        public async Task ReloadFromSourceAsync(Func<Task<List<TEntity>>> dataLoader)
        {
            var newItems = await dataLoader();
            await SetItemsAsync(newItems);
        }
    }
}
