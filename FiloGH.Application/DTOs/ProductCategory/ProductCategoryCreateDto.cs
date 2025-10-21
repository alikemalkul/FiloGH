using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.ProductCategory
{
    /// <summary>
    /// Yeni bir Ürün Kategorisi oluşturmak için kullanılan DTO.
    /// </summary>
    public record ProductCategoryCreateDto
    {
        [Required(ErrorMessage = "Kategori Kodu zorunludur.")]
        [MaxLength(10, ErrorMessage = "Kod en fazla 10 karakter olmalıdır.")]
        public required string Code { get; init; }

        [Required(ErrorMessage = "Kategori Adı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olmalıdır.")]
        public required string Name { get; init; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string? Description { get; init; }

        public bool IsActive { get; init; } = true;
    }
}
