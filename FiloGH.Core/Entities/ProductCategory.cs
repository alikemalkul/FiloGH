using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(50)]
        public string? Code { get; set; }

        public bool IsActive { get; set; } = true;

        // --- HİYERARŞİ (Kendine Referans) ---

        /// <summary>
        /// Üst kategorinin ID'si (Bu Entity'nin Id'si). Null ise ana kategoridir.
        /// </summary>
        public int? ParentId { get; set; }
        public ProductCategory? Parent { get; set; }

        /// <summary>
        /// Bu kategoriye bağlı alt kategoriler.
        /// </summary>
        public ICollection<ProductCategory> Children { get; set; } = new List<ProductCategory>();

        // --- İLİŞKİLER ---

        // public ICollection<Product> Products { get; set; } // Bu kategoriye ait ürünler
    }
}