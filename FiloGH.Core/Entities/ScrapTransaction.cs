using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim, rafinasyon veya diğer süreçlerden kaynaklanan metal hurda, fire veya kazanç hareketlerini izler.
    /// </summary>
    public class ScrapTransaction
    {
        public long Id { get; set; }

        public DateTimeOffset TransactionDate { get; set; } = DateTimeOffset.Now;

        public byte MetalCurrencyId { get; set; }
        public required Currency MetalCurrency { get; set; } = null!;

        public byte ScrapTypeId { get; set; }
        public required ScrapType ScrapType { get; set; } = null!; // Yeni Entity

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        /// <summary>
        /// Hurdanın kayda girdiği yerdeki ayar bilgisi (14K, 22K vb.).
        /// </summary>
        public byte KaratId { get; set; }
        public required Karat Karat { get; set; } = null!;

        /// <summary>
        /// Hurda hareketinin miktarı (Gram).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal WeightGrams { get; set; }

        /// <summary>
        /// Bu hurdaya neden olan Üretim Emri (Opsiyonel).
        /// </summary>
        public int? RelatedOrderId { get; set; }
        public ProductionOrder? RelatedOrder { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}