using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürün Reçetesinde kullanılan İşçilik/Ek Gider kalemlerinin türlerini tanımlar. (CostType -> BOMCostType olarak güncellendi)
    /// </summary>
    public class BOMCostType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Bu maliyet tipinin (işçilik, hizmet vb.) metal stok hareketini (kayıp/kazanç/fire) etkileyip etkilemediği.
        /// </summary>
        public bool AffectsMetalInventory { get; set; } = false; // Kuyumculuk ERP'si için kritik!

        public bool IsActive { get; set; } = true;

        // public ICollection<BOMLabor> Labors { get; set; } 
    }
}