using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.WorkOrderStatus
{
    /// <summary>
    /// Mevcut bir İş Emri Durumunu güncellemek için kullanılan DTO.
    /// </summary>
    public record WorkOrderStatusUpdateDto : WorkOrderStatusCreateDto
    {
        [Required(ErrorMessage = "Durum Kimliği zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Durum Kimliği belirtilmelidir.")]
        public required byte Id { get; init; }
    }
}
