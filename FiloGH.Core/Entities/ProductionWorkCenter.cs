using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretimin fiziksel olarak gerçekleştiği birimleri (Atölye, Makine Grubu) tanımlar.
    /// </summary>
    public class ProductionWorkCenter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!; // Hangi şubeye ait olduğu

        /// <summary>
        /// Bir vardiyada iş merkezinde işlenebilecek tahmini kapasite (saat veya adet).
        /// </summary>
        public short CapacityPerShift { get; set; } = 8; // Varsayılan 8 saat

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductionRoutingItem> RoutingItems { get; set; }
    }
}