using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs
{
    /// <summary>
    /// Bir ürüne ait varyant bilgisini (Örn: beden, renk, stok) tutar.
    /// </summary>
    public class ProductVariantDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Varyantın ait olduğu ürün ID'si zorunludur.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "SKU/Varyant Kodu zorunludur.")]
        [StringLength(50, ErrorMessage = "SKU en fazla 50 karakter olabilir.")]
        public string SKU { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Boyut bilgisi en fazla 50 karakter olabilir.")]
        public string Size { get; set; } = string.Empty; // Örn: 10 Karat, 40 cm

        [StringLength(50, ErrorMessage = "Renk bilgisi en fazla 50 karakter olabilir.")]
        public string Color { get; set; } = string.Empty; // Örn: Beyaz Altın, Rose Gold

        [Range(0, 100000, ErrorMessage = "Stok miktarı 0 ile 100.000 arasında olmalıdır.")]
        public int StockQuantity { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
