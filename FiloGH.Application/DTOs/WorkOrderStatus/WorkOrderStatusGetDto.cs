using System;

namespace FiloGH.Application.DTOs.WorkOrderStatus
{
    /// <summary>
    /// İş Emri Durumu bilgilerini listeleme veya detay gösterme amaçlı kullanılan DTO.
    /// </summary>
    public record WorkOrderStatusGetDto
    {
        public required byte Id { get; init; }
        public required string Code { get; init; }
        public required string Name { get; init; }
        public required bool IsInProduction { get; init; }
        public required bool IsEditable { get; init; }
        public string? Description { get; init; }

        // İzleme Bilgileri
        public required DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
