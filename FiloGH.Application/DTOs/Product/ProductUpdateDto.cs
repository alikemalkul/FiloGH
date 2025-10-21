using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Product
{
    /// <summary>
    /// Mevcut bir ürünün bilgilerini güncellemek için kullanılan DTO.
    /// </summary>
    public record ProductUpdateDto : ProductCreateDto
    {
        [Required(ErrorMessage = "Ürün Kimliği zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Ürün Kimliği belirtilmelidir.")]
        public required int Id { get; init; }
    }
}
