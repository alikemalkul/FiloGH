using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ölçü Birimlerinin (Gram, Adet vb.) kategorisini tanımlar (Ağırlık, Adet, Hacim).
    /// </summary>
    public class UomType : IEntity<byte>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // byte optimizasyonu

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; }

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        public ICollection<UnitOfMeasure> UnitOfMeasures { get; set; } = new List<UnitOfMeasure>();
    }
}