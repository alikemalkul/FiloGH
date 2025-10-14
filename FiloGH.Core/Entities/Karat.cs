using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Kıymetli metallerin ayar ve saflık derecelerini tanımlar (Karat bilgisi).
    /// </summary>
    public class Karat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; } // Örn: 14K

        [MaxLength(50)]
        public required string Name { get; set; } // Örn: 14 Ayar

        /// <summary>
        /// Metalin saflık oranı (14K = 0.5850, 18K = 0.7500). Stok takibi için esastır.
        /// </summary>
        [Column(TypeName = "decimal(5,4)")]
        public decimal Fineness { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductVariant> ProductVariants { get; set; }
        // public ICollection<ScrapTransaction> ScrapTransactions { get; set; }
    }
}