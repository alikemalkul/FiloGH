using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürünün genel tanımı, kategorisi ve marka bilgisi. (Örn: Klasik Tektaş Yüzük)
    /// </summary>
    public class Product : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Ürüne ait SKU (Stok Kodu) veya Model Kodu.
        /// </summary>
        [MaxLength(50)]
        public required string ProductCode { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
        /// <summary>
        /// Ürünün stokta tutulduğu birim ID'si (Adet, Gram, Ons vb.).
        /// </summary>

        // --- KUYUMCULUK ÖZELLİKLERİ VE KATEGORİLEME ---

        /// <summary>
        /// Ürünün ait olduğu kategori (Yüzük, Kolye, Küpe vb.).
        /// </summary>
        public int ProductCategoryId { get; set; }
        public required ProductCategory Category { get; set; } = null!; // Yeni Entity olarak eklenecek

        /// <summary>
        /// Ürünün tasarımı/kalıbı ile ilgili benzersiz referans (Örn: 5001).
        /// </summary>
        [MaxLength(50)]
        public string? DesignCode { get; set; }

        /// <summary>
        /// Ürünün markası (Opsiyonel).
        /// </summary>
        public byte? BrandId { get; set; }
        public Brand? Brand { get; set; } // Yeni Entity olarak eklenecek

        // --- İLİŞKİLER ---
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}