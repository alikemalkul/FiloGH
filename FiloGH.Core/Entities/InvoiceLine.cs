using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Fatura üzerindeki her bir ürün kaleminin detaylarını ve fiyatlandırma bilgilerini tutar.
    /// </summary>
    public class InvoiceLine
    {
        public long Id { get; set; }

        public int InvoiceId { get; set; }
        public required Invoice Invoice { get; set; } = null!;

        public short LineNumber { get; set; }

        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        public byte UnitId { get; set; }
        public required UnitOfMeasure Unit { get; set; } = null!;

        // --- MİKTARLAR ---

        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmount { get; set; } = 0.0M;

        [Column(TypeName = "decimal(18,4)")]
        public decimal LineAmount { get; set; } // Vergisiz Satır Toplamı

        // --- VERGİ VE SİPARİŞ İLİŞKİLERİ ---

        public byte TaxRateId { get; set; }
        public required TaxRate TaxRate { get; set; } = null!;

        /// <summary>
        /// Faturanın kesildiği orijinal sipariş satırı (RootType'a bakılmaksızın OrderLine).
        /// </summary>
        public int? OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }
    }
}