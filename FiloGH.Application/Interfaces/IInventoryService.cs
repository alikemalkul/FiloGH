using FiloGH.Core.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FiloGH.Application.Interfaces
{
    /// <summary>
    /// Stok hareketlerini, bakiyeleri ve envanter yönetimini yöneten servistir.
    /// Kuyumculuk sektörüne özel olarak metal saflığı ve maliyet takibi içerir.
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Yeni bir stok hareketi (Giriş/Çıkış/Transfer) kaydeder.
        /// Bu metot, Metal ve Maliyet bilgisiyle birlikte tek bir transaction kaydı oluşturur.
        /// </summary>
        /// <param name="movementTypeId">Hareketi tanımlayan ID (Alış, Satış Çıkışı vb.).</param>
        /// <param name="branchId">Hareketi yapan şube.</param>
        /// <param name="locationId">Stoğun gittiği/çıktığı lokasyon.</param>
        /// <param name="metalPurityId">Metal Ayarı (14K, 22K).</param>
        /// <param name="weightInGrams">Ticari ağırlık (Pozitif: Giriş, Negatif: Çıkış).</param>
        /// <param name="sourceDocType">Hareketi tetikleyen belge türü (Order, Production).</param>
        Task<StockTransaction> RecordTransactionAsync(
            byte movementTypeId,
            byte branchId,
            byte locationId,
            byte? metalPurityId,
            decimal weightInGrams,
            string sourceDocType,
            int? sourceDocId, // Belgenin ID'si (Örn: WorkOrderId)
            byte createdById
        );

        /// <summary>
        /// İki lokasyon arasında stok transferi gerçekleştirir (Tek bir atomik transaction içinde iki hareket kaydı oluşturur).
        /// </summary>
        Task<bool> TransferStockAsync(
            byte transferMovementTypeId,
            byte branchId,
            byte fromLocationId,
            byte toLocationId,
            decimal weightInGrams,
            int createdById
        );

        /// <summary>
        /// Belirli bir lokasyondaki belirli bir metal/ayarın (pure metal) anlık bakiyesini hesaplar.
        /// Bu, tüm StockTransaction kayıtlarının toplamıdır.
        /// </summary>
        /// <param name="locationId">Stok Lokasyonu ID'si.</param>
        /// <param name="metalPurityId">Metal Ayarı (Örn: 14K).</param>
        /// <returns>Toplam Ticari Ağırlık (Gram).</returns>
        Task<decimal> GetStockBalanceByPurityAsync(int locationId, byte metalPurityId);

        /// <summary>
        /// Belirli bir Ayar (Purity) ve Lokasyon için Ortalama Maliyeti hesaplar.
        /// </summary>
        Task<decimal> GetAverageCostPerGramAsync(byte metalPurityId, int locationId);
    }
}
