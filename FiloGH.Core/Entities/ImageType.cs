using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürün görsellerinin (ProductImage) kullanım amacını veya tipini tanımlar.
    /// </summary>
    public class ImageType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Az sayıda tip olacağı için byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: Ana Görsel, Kutu Fotoğrafı, Model Çekimi

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: MAIN, BOX, MODEL

        /// <summary>
        /// Bu tipteki görsellerin öncelik sırası veya varsayılan konumu.
        /// </summary>
        public short SortOrder { get; set; } = 1;

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductImage> ProductImages { get; set; }
    }
}