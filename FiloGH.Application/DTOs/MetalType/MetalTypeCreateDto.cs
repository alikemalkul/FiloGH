using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.MetalType
{
    /// <summary>
    /// Yeni bir Metal Tipi oluşturmak için kullanılan DTO.
    /// Kuyumculuk ERP'sinde Ayar (925, 585, 750) veya Renk (Sarı, Beyaz, Rose) bilgisini ifade edebilir.
    /// </summary>
    public record MetalTypeCreateDto
    {
        [Required(ErrorMessage = "Metal Tipi Kodu zorunludur.")]
        [MaxLength(10, ErrorMessage = "Kod en fazla 10 karakter olmalıdır.")]
        public required string Code { get; init; }

        [Required(ErrorMessage = "Metal Tipi Adı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Ad en fazla 50 karakter olmalıdır.")]
        public required string Name { get; init; }

        [Required(ErrorMessage = "Fiyat Çarpanı zorunludur.")]
        [Range(0.0001, 100.0, ErrorMessage = "Çarpan, sıfırdan büyük ve 100'den küçük olmalıdır.")]
        public required decimal PriceMultiplier { get; init; }

        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olmalıdır.")]
        public string? Description { get; init; }

        public bool IsActive { get; init; } = true;
    }
}
