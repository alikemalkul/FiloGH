using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.ProductCategory
{
    /// <summary>
    /// Mevcut bir Ürün Kategorisini güncellemek için kullanılan DTO.
    /// </summary>
    public record ProductCategoryUpdateDto : ProductCategoryCreateDto
    {
        [Required(ErrorMessage = "Kategori Kimliği zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Kategori Kimliği belirtilmelidir.")]
        public required byte Id { get; init; }
    }
}
