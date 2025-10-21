using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.WorkOrderStatus
{
    /// <summary>
    /// Yeni bir İş Emri Durumu oluşturmak için kullanılan DTO.
    /// </summary>
    public record WorkOrderStatusCreateDto
    {
        [Required(ErrorMessage = "Durum Kodu zorunludur (Örn: NEW, WIP, COMP).")]
        [MaxLength(10, ErrorMessage = "Kod en fazla 10 karakter olmalıdır.")]
        public required string Code { get; init; }

        [Required(ErrorMessage = "Durum Adı zorunludur (Örn: Yeni Oluşturuldu, Üretimde).")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olmalıdır.")]
        public required string Name { get; init; }

        /// <summary>
        /// Bu durumdayken iş emrinin aktif olarak üretimde sayılıp sayılmayacağını belirtir.
        /// (Örn: WIP - True, NEW - False, CANCELLED - False)
        /// </summary>
        public required bool IsInProduction { get; init; }

        /// <summary>
        /// Bu durumdayken iş emrinin güncellenebilir olup olmadığını belirtir.
        /// (Örn: NEW - True, COMPLETED - False)
        /// </summary>
        public required bool IsEditable { get; init; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string? Description { get; init; }
    }
}
