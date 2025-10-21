using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.MetalType
{
    /// <summary>
    /// Mevcut bir Metal Tipini güncellemek için kullanılan DTO.
    /// </summary>
    public record MetalTypeUpdateDto : MetalTypeCreateDto
    {
        [Required(ErrorMessage = "Metal Tipi Kimliği zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Metal Tipi Kimliği belirtilmelidir.")]
        public required byte Id { get; init; }
    }
}
