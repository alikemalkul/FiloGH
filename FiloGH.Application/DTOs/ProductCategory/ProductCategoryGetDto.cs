using System;
using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.ProductCategory
{
    /// <summary>
    /// Ürün Kategorisi bilgilerini listeleme veya detay gösterme amaçlı kullanılan DTO.
    /// </summary>
    public record ProductCategoryGetDto
    {
        public required byte Id { get; init; }
        public required string Code { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required bool IsActive { get; init; }

        // İzleme Bilgileri
        public required DateTimeOffset CreatedAt { get; init; }
        public required int CreatedById { get; init; }
        public string? CreatedByName { get; init; } // Eğer kullanıcı bilgisi Join ile çekiliyorsa
        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
