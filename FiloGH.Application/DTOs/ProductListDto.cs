using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs
{
    // Product Listeleme ekranında görünecek temel veriler
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty; // Birden fazla varyant SKU'su birleştirilebilir veya ana ürün kodu kullanılabilir
        public string CategoryName { get; set; } = string.Empty;
        public int TotalStockQuantity { get; set; } // Tüm varyantlardaki toplam stok
    }
}
