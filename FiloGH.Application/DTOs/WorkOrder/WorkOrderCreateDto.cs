using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.WorkOrder
{
    /// <summary>
    /// Yeni bir İş Emri oluşturmak için kullanılan DTO.
    /// Kuyumculuk ERP'sinde bir ürünün üretim siparişini temsil eder.
    /// </summary>
    public record WorkOrderCreateDto
    {
        [Required(ErrorMessage = "Ürün Kimliği (Product Id) zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir Ürün Kimliği belirtilmelidir.")]
        public required int ProductId { get; init; }

        [Required(ErrorMessage = "Metal Tipi Kimliği (Metal Type Id) zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Metal Tipi Kimliği belirtilmelidir.")]
        public required byte MetalTypeId { get; init; }

        [Required(ErrorMessage = "İş Emri Durum Kimliği (Work Order Status Id) zorunludur. (Örn: NEW)")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir İş Emri Durum Kimliği belirtilmelidir.")]
        public required byte StatusId { get; init; }

        [Required(ErrorMessage = "Sipariş Miktarı zorunludur.")]
        [Range(1, 10000, ErrorMessage = "Miktar 1 ile 10000 arasında olmalıdır.")]
        public required int Quantity { get; init; }

        [Required(ErrorMessage = "Planlanan Başlangıç Tarihi zorunludur.")]
        public required DateTimeOffset PlannedStartDate { get; init; }

        public DateTimeOffset? PlannedCompletionDate { get; init; }

        [MaxLength(20, ErrorMessage = "Referans Kod en fazla 20 karakter olmalıdır.")]
        public string? ReferenceCode { get; init; }

        [MaxLength(500, ErrorMessage = "Notlar en fazla 500 karakter olmalıdır.")]
        public string? Notes { get; init; }
    }
}
