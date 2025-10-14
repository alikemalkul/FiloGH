using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// BillOfMaterials (Reçete)'in kullanım amacını (Üretim, Satış vb.) tanımlar.
    /// </summary>
    public class BOMType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<BillOfMaterials> BOMs { get; set; }
    }
}