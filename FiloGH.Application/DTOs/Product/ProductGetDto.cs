using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Product
{
    /// <summary>
    /// Ürün bilgilerini listeleme veya detay gösterme amaçlı kullanılan DTO.
    /// İlişkili Entity'lerin adlarını içerir.
    /// </summary>
    public record ProductGetDto
    {
        public required int Id { get; init; }
        public required string Code { get; init; }
        public required string Name { get; init; }

        // Kategori Bilgileri
        public required int ProductCategoryId { get; init; }
        public required string ProductCategoryName { get; init; }

        // Metal Tipi Bilgileri
        public required byte MetalTypeId { get; init; }
        public required string MetalTypeName { get; init; }

        // Ağırlık ve Fiyat Bilgileri
        public required decimal AverageWeight { get; init; }
        public required decimal MinimumWeight { get; init; }
        public required decimal MaximumWeight { get; init; }
        public required decimal CostPrice { get; init; }
        public required decimal SellingPrice { get; init; }

        // Durum Bilgileri
        public required bool IsActive { get; init; }
        public required bool CanBeSold { get; init; }
        public required bool CanBeProduced { get; init; }

        // İzleme Bilgileri
        public required DateTimeOffset CreatedAt { get; init; }
        public required int CreatedById { get; init; }
        public string? CreatedByName { get; init; } // Kullanıcı adını da göstermek için

        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
