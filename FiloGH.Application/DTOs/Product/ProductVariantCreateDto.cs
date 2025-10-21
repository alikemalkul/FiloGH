using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Product
{
    /// <summary>Ürün varyantı oluşturmak için DTO (ProductCreateDto içinde veya ayrı endpoint’te kullanılabilir).</summary>
    public class ProductVariantCreateDto
    {
        [MaxLength(100, ErrorMessage = "Barkod en fazla 100 karakter olabilir.")]
        public string? Barcode { get; set; }

        [Required(ErrorMessage = "SKU (Varyant kodu) zorunludur.")]
        [MaxLength(100, ErrorMessage = "SKU en fazla 100 karakter olabilir.")]
        public string SKU { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Tedarikçi kodu en fazla 100 karakter olabilir.")]
        public string? SupplierCode { get; set; }

        [Required(ErrorMessage = "Varyant adı zorunludur.")]
        [MaxLength(255, ErrorMessage = "Varyant adı en fazla 255 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public byte? MetalPurityId { get; set; }
        public byte? MetalColorId { get; set; }

        // EF: decimal(6,1)  => max 99_999.9
        [Range(typeof(decimal), "0", "99999.9", ErrorMessage = "Beden 0 ile 99.999,9 arasında olmalıdır.")]
        public decimal? Size { get; set; }

        // EF: decimal(6,1)  => max 99_999.9
        [Range(typeof(decimal), "0", "99999.9", ErrorMessage = "Uzunluk 0 ile 99.999,9 arasında olmalıdır.")]
        public decimal? Length { get; set; }

        // EF: decimal(10,4) => max 9_999_99.9999 (toplam 10 basamak)
        [Range(typeof(decimal), "0", "999999.9999", ErrorMessage = "Standart ağırlık 0 ile 999.999,9999 arasında olmalıdır.")]
        public decimal StandardWeight { get; set; }

        // EF: decimal(18,4) => geniş aralık; makul üst sınır belirliyoruz
        [Range(typeof(decimal), "0", "999999999.9999", ErrorMessage = "Standart maliyet 0 ile 999.999.999,9999 arasında olmalıdır.")]
        public decimal StandardCost { get; set; }

        public bool IsWeightBasedPricing { get; set; }

        [Required(ErrorMessage = "Stok birimi zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir stok birimi seçiniz.")]
        public byte StockUnitId { get; set; }
    }
}
