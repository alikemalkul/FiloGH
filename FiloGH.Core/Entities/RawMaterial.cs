using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim süreçlerinde kullanılan metal ve taş dışındaki tüm sarf malzemelerini (kutu, etiket, klips vb.) tanımlar.
    /// </summary>
    public class RawMaterial
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Code { get; set; }

        [MaxLength(150)]
        public required string Name { get; set; }

        public byte MaterialTypeId { get; set; }
        public required RawMaterialType MaterialType { get; set; } = null!; // Yeni Entity

        public byte UnitId { get; set; }
        public required UnitOfMeasure Unit { get; set; } = null!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal StandardCost { get; set; } = 0.0M;

        /// <summary>
        /// Malzemenin stokta tükenip tükenmediği (Sarf olup olmadığı).
        /// </summary>
        public bool IsConsumable { get; set; } = true;

        public bool IsActive { get; set; } = true;

        // public ICollection<InventoryMovement> Movements { get; set; } // Stok hareketleri
    }
}