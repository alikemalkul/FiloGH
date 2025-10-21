using System;

namespace FiloGH.Application.DTOs.MetalType
{
    /// <summary>
    /// Metal Tipi bilgilerini listeleme veya detay gösterme amaçlı kullanılan DTO.
    /// </summary>
    public record MetalTypeGetDto
    {
        public required byte Id { get; init; }
        public required string Code { get; init; }
        public required string Name { get; init; }
        public required decimal PriceMultiplier { get; init; }
        public string? Description { get; init; }
        public required bool IsActive { get; init; }

        // İzleme Bilgileri
        public required DateTimeOffset CreatedAt { get; init; }
        public required int CreatedById { get; init; }
        public string? CreatedByName { get; init; }
        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
