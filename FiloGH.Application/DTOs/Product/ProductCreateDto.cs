using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Product
{
    /// <summary>Yeni ürün + isteğe bağlı varyantları birlikte oluşturmak için DTO.</summary>
    public record ProductCreateDto
    {
        // Temel Ürün Bilgileri (Product Entity baz alınmıştır)
        [Required(ErrorMessage = "Ürün Kodu zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ürün Kodu en fazla 50 karakter olabilir.")] // Entity: Max 50 [11]
        public required string ProductCode { get; init; }

        [Required(ErrorMessage = "Ürün Adı zorunludur.")]
        [MaxLength(255, ErrorMessage = "Ürün Adı en fazla 255 karakter olabilir.")] // Entity: Max 255 [11]
        public required string Name { get; init; }

        [Required(ErrorMessage = "Kategori ID'si zorunludur.")]
        public required int ProductCategoryId { get; init; } // Entity: int [1]

        [MaxLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")] // Entity: Max 1000 [11]
        public string? Description { get; init; }

        [MaxLength(50, ErrorMessage = "Tasarım Kodu en fazla 50 karakter olabilir.")] // Entity: Max 50 [1]
        public string? DesignCode { get; init; }

        public byte? BrandId { get; init; } // Entity: byte? [1]

        public bool IsActive { get; init; } = true; // Entity: Default true [1]

        // İş/Envanter Bilgileri (ProductGetDto zorunluluklarına göre eklendi - Product Entity'sinde yoktur)
        [Required(ErrorMessage = "Metal Tipi zorunludur.")]
        public required byte MetalTypeId { get; init; } // ProductGetDto'da zorunludur [12]

        [Required(ErrorMessage = "Ortalama Ağırlık zorunludur.")]
        public required decimal AverageWeight { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Minimum Ağırlık zorunludur.")]
        public required decimal MinimumWeight { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Maksimum Ağırlık zorunludur.")]
        public required decimal MaximumWeight { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Maliyet Fiyatı zorunludur.")]
        public required decimal CostPrice { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Satış Fiyatı zorunludur.")]
        public required decimal SellingPrice { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Satış Durumu zorunludur.")]
        public required bool CanBeSold { get; init; } // ProductGetDto'da zorunludur [13]

        [Required(ErrorMessage = "Üretim Durumu zorunludur.")]
        public required bool CanBeProduced { get; init; } // ProductGetDto'da zorunludur [2]

        // İlişkili Varyantlar
        public ICollection<ProductVariantCreateDto> Variants { get; init; } = new List<ProductVariantCreateDto>();
    }
}
