using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim Emri'nin (ProductionOrder) yaşam döngüsündeki anlık durumlarını tanımlar.
    /// </summary>
    public class ProductionOrderStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductionOrder> Orders { get; set; }
    }
}