using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim Emri'ne karşı yapılan tüm sarfiyat, işçilik süresi ve çıktı hareketlerini kaydeder.
    /// </summary>
    public class ProductionTransaction
    {
        public long Id { get; set; }

        public int OrderId { get; set; }
        public required ProductionOrder Order { get; set; } = null!;

        public int? RoutingStepId { get; set; } // Bu işlemin rotanın hangi adımında gerçekleştiği
        public ProductionRoutingStep? RoutingStep { get; set; }

        public byte TransactionTypeId { get; set; }
        public required ProductionTransactionType TransactionType { get; set; } = null!; // Yeni Entity

        public DateTimeOffset TransactionDate { get; set; } = DateTimeOffset.Now;
        
        // --- İLİŞKİLER ---

        /// <summary>
        /// Bu sarfiyatın ait olduğu ana Üretim Emri.
        /// </summary>
        public int ProductionOrderId { get; set; } // Foreign Key
        public required ProductionOrder ProductionOrder { get; set; } = null!;

        // --- QUANTITY / ITEM ---

        /// <summary>
        /// Harekete konu olan ürün (metal, taş veya bitmiş ürün) varyantı.
        /// </summary>
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        /// <summary>
        /// Sarf edilen/üretilen miktar (Gram, Karat, Saat, Adet).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal Quantity { get; set; }

        public byte UnitId { get; set; }
        public required UnitOfMeasure Unit { get; set; } = null!; // UnitOfMeasure (Gram, Karat, Saat, vb.)

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}