using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Metalin rengini tanımlar (Örn: Sarı, Beyaz, Rose). 
    /// Bu, varyantları ayırmada kritik rol oynar.
    /// </summary>
    public class MetalColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Rengin kullanıcıya görünen adı (Örn: Sarı Altın, Platin Beyazı).
        /// </summary>
        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// Rengin kısaltması veya kodu (Örn: SAR, BYZ, ROS).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        // Opsiyonel: Renk değerini UI'da göstermek için (Hex kodu)
        [MaxLength(7)]
        public string? HexCode { get; set; }

        public bool IsActive { get; set; } = true;

        // İlişki: Bu renge sahip tüm varyantlar (Opsiyonel: Navigasyon için)
        // public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}