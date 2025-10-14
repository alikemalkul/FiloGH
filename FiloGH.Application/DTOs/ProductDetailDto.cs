using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs
{
    /// <summary>
    /// Bir ürünün tüm detaylarını ve varyant listesini tutar. Form ve Detay sayfaları için kullanılır.
    /// </summary>
    public class ProductDetailDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün Adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Ürün Adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori zorunludur.")]
        [StringLength(50, ErrorMessage = "Kategori Adı en fazla 50 karakter olabilir.")]
        public string CategoryName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Ürüne ait varyantların listesi.
        /// </summary>
        public List<ProductVariantDto> Variants { get; set; } = new List<ProductVariantDto>();
    }
}
