using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Stok seviyesindeki her türlü değişikliği kaydeden denetim/hareket kaydı.
    /// </summary>
    public class InventoryTransaction
    {
        public int Id { get; set; }

        public DateTimeOffset MovementDate { get; set; } = DateTimeOffset.Now;

        // --- BOYUTLAR (Dimension) ---
        public int StockItemId { get; set; }
        public required StockItem StockItem { get; set; } = null!; // ✅ StockItem FK

        public byte LocationId { get; set; }
        public required Location Location { get; set; } = null!; // ✅ Location FK

        public byte TransactionTypeId { get; set; }
        public required InventoryTransactionType TransactionType { get; set; } = null!; // ✅ TransactionType FK

        // --- MİKTARLAR (Quantities) ---

        /// <summary>
        /// Hareket miktarı (BaseUnit cinsinden). Giriş için pozitif, Çıkış için negatif.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Bu hareketteki toplam brüt metal ağırlığı değişimi (Gram/Ons).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal MetalWeightGross { get; set; }

        /// <summary>
        /// Bu hareketteki toplam net/has metal ağırlığı değişimi (Gram/Ons).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal MetalWeightNet { get; set; }

        /// <summary>
        /// Bu hareketteki toplam taş Karat ağırlığı değişimi (ct).
        /// </summary>
        [Column(TypeName = "decimal(10,4)")]
        public decimal CaratWeight { get; set; } = 0.0M;

        // --- MALİYET VE REFERANSLAR ---

        /// <summary>
        /// Bu hareketin birim başına maliyeti (BaseCurrency cinsinden).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal UnitCost { get; set; }

        /// <summary>
        /// Bağlı olduğu kaynak (Sipariş, Üretim Emri, Sayım Belgesi vb.).
        /// </summary>
        public int? SourceOrderId { get; set; }
        public Order? SourceOrder { get; set; } // ✅ Order FK
    }
}