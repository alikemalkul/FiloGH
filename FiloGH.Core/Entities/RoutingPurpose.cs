using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim Rotası'nın (ProductionRouting) kullanım amacını tanımlar.
    /// </summary>
    public class RoutingPurpose
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Az sayıda amaç olacağı için byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: Üretim Rotası, Standart Maliyet Rotası

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: MFG, COSTING

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductionRoutingItem> RoutingItems { get; set; }
    }
}