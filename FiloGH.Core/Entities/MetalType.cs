using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class MetalType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// Metalin ticari kodu (Örn: XAU - Altın, XAG - Gümüş).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Metalin birincil stok takibi birimi (Örn: Gram, Ons).
        /// </summary>
        public byte BaseUnitId { get; set; }
        public required UnitOfMeasure BaseUnit { get; set; } = null!; // UnitOfMeasure Entity'sine FK

        /// <summary>
        /// Metalin değerli metal kategorisinde olup olmadığı (Muhasebe/Vergi ayrımı için).
        /// </summary>
        public bool IsPrecious { get; set; } = true;

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        public required ICollection<MetalPurity> Purities { get; set; } = new List<MetalPurity>(); // Bu metale ait ayarlar (14K, 18K vb.)
        // public ICollection<DailyRate> DailyRates { get; set; } // Bu metale ait günlük fiyatlar
    }
}