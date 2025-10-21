using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Product
{
    public record ProductVariantGetDto
    {
        // Temel Kimlikler
        public required int Id { get; init; }
        public required int ProductId { get; init; }

        // Temel Veriler
        [MaxLength(100)]
        public required string SKU { get; init; }
        [MaxLength(255)]
        public required string Name { get; init; }
        [MaxLength(100)]
        public string? Barcode { get; init; }
        [MaxLength(100)]
        public string? SupplierCode { get; init; }
        public required bool IsActive { get; init; }

        // Stok ve Fiyatlandırma Birimleri
        public required byte StockUnitId { get; init; }
        public required string StockUnitName { get; init; } // UnitOfMeasure.Name
        public required decimal StandardWeight { get; init; }
        public required decimal StandardCost { get; init; }
        public required bool IsWeightBasedPricing { get; init; }

        // Ölçü ve Boyutlar
        public decimal? Size { get; init; }
        public decimal? Length { get; init; }

        // Metal Bilgileri (MetalPurity ve MetalColor Dış Anahtarları)
        public byte? MetalPurityId { get; init; }
        public string? MetalPurityName { get; init; } // MetalPurity.Name
        public byte? MetalColorId { get; init; }
        public string? MetalColorName { get; init; } // MetalColor.Name

        // Denetim (Audit) Alanları
        // Not: Product Variant Entity'sinde Created/Modified alanları tanımlanmamış olabilir, ancak DTO genel olarak bunları bekleyebilir.
        public required DateTimeOffset CreatedAt { get; init; }
        public required int CreatedById { get; init; }
        public string? CreatedByName { get; init; }
        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
