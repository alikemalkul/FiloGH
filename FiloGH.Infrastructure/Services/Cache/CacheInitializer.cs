using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FiloGH.Infrastructure.Services.Cache
{
    // IHostedService uygulaması, uygulama başladığında veritabanından önbelleğe veri yükler.
    public class CacheInitializer : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CacheInitializer> _logger;

        public CacheInitializer(IServiceScopeFactory scopeFactory, ILogger<CacheInitializer> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Önbellek başlatma işlemi başlatılıyor...");

            // Önbellek yüklemeleri başlatılıyor.

            // Branch yükleniyor (ID tipi: byte)
            await LoadAndSetCacheAsync<Branch, byte>(cancellationToken);

            // Currency yükleniyor (ID tipi: byte)
            await LoadAndSetCacheAsync<Currency, byte>(cancellationToken);

            // UomType entity'si yükleniyor (ID tipi: byte)
            await LoadAndSetCacheAsync<UomType, byte>(cancellationToken);

            _logger.LogInformation("Tüm önbellek başlatma işlemleri tamamlandı.");
        }

        /// <summary>
        /// Belirtilen entity tipini (TEntity) veritabanından çeker ve ilgili ICacheService'e yükler.
        /// Entity'nin IEntity<TId> uygulaması gerekir.
        /// </summary>
        /// <typeparam name="TEntity">Önbelleğe alınacak entity tipi.</typeparam>
        /// <typeparam name="TId">Entity'nin ID tipi (int, byte vb.).</typeparam>
        private async Task LoadAndSetCacheAsync<TEntity, TId>(CancellationToken cancellationToken)
            where TEntity : class, IEntity<TId>
            where TId : struct, System.IComparable, System.IConvertible, System.IComparable<TId>, System.IEquatable<TId>
        {
            var entityName = typeof(TEntity).Name;
            _logger.LogInformation("Başlatılıyor: {EntityName} önbelleği.", entityName);

            try
            {
                // Scoped servisleri çekmek için yeni bir scope oluşturulur.
                using var scope = _scopeFactory.CreateScope();

                var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var repository = uow.GetRepository<TEntity, TId>();
                var cacheService = scope.ServiceProvider.GetRequiredService<ICacheService<TEntity>>();

                // Tüm veriyi takip etmeden (AsNoTracking) çekeriz.
                IEnumerable<TEntity> items = await repository.GetAllAsync(disableTracking: true);

                // Çekilen veriyi List<TEntity>'ye dönüştürerek Singleton servise aktarır.
                // CS1503 hatasını çözmek için ToList() eklendi.
                await cacheService.SetItemsAsync(items.ToList());

                _logger.LogInformation("Başarılı: {EntityName} önbelleği yüklendi. Toplam {Count} kayıt.", entityName, items.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HATA: {EntityName} önbelleği yüklenirken bir sorun oluştu.", entityName);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
