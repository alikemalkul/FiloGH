using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir ProductVariant'a ait görsel dosyalarının ve meta bilgilerinin depolandığı Entity.
    /// </summary>
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        /// <summary>
        /// Görselin sunucudaki veya CDN'deki tam yolu/URL'si.
        /// </summary>
        [MaxLength(500)]
        public required string ImageUrl { get; set; }

        /// <summary>
        /// Görselin sıralaması (Örn: 1 = Ana Görsel, 2 = İkinci Görsel).
        /// </summary>
        public short SortOrder { get; set; } = 1;

        /// <summary>
        /// Görselin kısa açıklaması veya ALT metni.
        /// </summary>
        [MaxLength(255)]
        public string? AltText { get; set; }

        /// <summary>
        /// Görselin tipini (Ürün, Ambalaj, Model çekimi vb.) belirten FK (Opsiyonel).
        /// </summary>
        public byte? ImageTypeId { get; set; }
        public ImageType? ImageType { get; set; } // Varsayımsal ImageType Entity'sine FK
    }
}