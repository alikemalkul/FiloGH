using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir üründeki taşın türünü (Pırlanta, Yakut, Sentetik vb.) tanımlar. (İsim güncellendi: StoneType -> BOMStoneType)
    /// </summary>
    public class BOMStoneType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public string? Code { get; set; }

        /// <summary>
        /// Taşın değerli (precious) olup olmadığı (Örn: Pırlanta, Safir için True).
        /// </summary>
        public bool IsPrecious { get; set; } = false;

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        /// <summary>
        /// Taşın envanter takibinde kullanılan birincil birimi (Genellikle Karat/ct veya Adet/pc).
        /// </summary>
        public byte BaseUnitId { get; set; }
        public required UnitOfMeasure BaseUnit { get; set; } = null!; // UnitOfMeasure Entity'sine FK

        // public ICollection<BillOfMaterialsStone> StoneUsages { get; set; }
    }
}