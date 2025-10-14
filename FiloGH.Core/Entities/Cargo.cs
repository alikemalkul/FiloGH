using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Sevkiyatlarda kullanılan kargo ve lojistik firmalarının temel bilgilerini tanımlar.
    /// </summary>
    public class Cargo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Genellikle az sayıda kargo firması olacağı için byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: UPS, FedEx, Yurtiçi Kargo

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: UPS, FEDEX, YURTICI

        /// <summary>
        /// Kargo firmasının online takip URL'si (Tracking Number bu URL'ye eklenerek kullanılabilir).
        /// </summary>
        [MaxLength(255)]
        public string? TrackingUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // Kargo fiyat listesi, entegrasyon ayarları gibi detaylar buraya eklenebilir.
    }
}