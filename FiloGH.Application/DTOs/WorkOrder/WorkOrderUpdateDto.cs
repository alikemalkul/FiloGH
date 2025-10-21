using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.WorkOrder
{
    /// <summary>
    /// Mevcut bir İş Emrini güncellemek için kullanılan DTO.
    /// </summary>
    public record WorkOrderUpdateDto : WorkOrderCreateDto
    {
        [Required(ErrorMessage = "İş Emri Kimliği zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir İş Emri Kimliği belirtilmelidir.")]
        public required int Id { get; init; }

        // Diğer tüm alanlar WorkOrderCreateDto'dan devralınmıştır.
    }
}
