using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Tüm vergi oranlarını (KDV, ÖTV vb.) ve geçerlilik tarihlerini tanımlar.
    /// </summary>
    public class TaxRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Vergi oranı yüzdesi (Örn: 18.00).
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal RatePercentage { get; set; }

        /// <summary>
        /// Bu vergi oranının geçerli olduğu başlangıç tarihi (Zamanla değişebilen oranlar için kritik).
        /// </summary>
        public DateTimeOffset ValidFromDate { get; set; } = DateTimeOffset.Now;

        public bool IsActive { get; set; } = true;
    }
}