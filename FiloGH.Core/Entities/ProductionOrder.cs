using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürün Reçetesi (BOM) ve Rota (Routing) bilgilerini kullanarak oluşturulan ana iş emri kaydı.
    /// </summary>
    public class ProductionOrder
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public required string OrderNumber { get; set; }

        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Quantity { get; set; }

        public byte StatusId { get; set; }
        public required ProductionOrderStatus Status { get; set; } = null!; // Yeni Entity

        public int BomId { get; set; }
        public required BillOfMaterials Bom { get; set; } = null!;

        public int RoutingId { get; set; }
        public required ProductionRouting Routing { get; set; } = null!;

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        public DateTimeOffset ScheduledStartDate { get; set; }
        public DateTimeOffset ScheduledEndDate { get; set; }

        public DateTimeOffset? ActualStartDate { get; set; } // Üretimin fiilen başladığı tarih
        public DateTimeOffset? ActualEndDate { get; set; } // Üretimin fiilen bittiği tarih

        // --- İLİŞKİLER ---
        /// <summary>
        /// Bu üretim emrine ait Sarfiyat ve İşleme (Input/Output) hareketleri.
        /// </summary>
        public ICollection<ProductionTransaction> Transactions { get; set; } = new List<ProductionTransaction>(); // Sarfiyat ve işleme hareketleri
    }
}