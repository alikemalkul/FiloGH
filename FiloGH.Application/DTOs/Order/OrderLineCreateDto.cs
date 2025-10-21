using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Order
{
    // Bu, OrderCreateDto içinde bir koleksiyon olarak kullanılacaktır.
    public record OrderLineCreateDto
    {
        // Hangi ürün varyantının sipariş edildiği zorunludur.
        public required int ProductVariantId { get; init; }

        // Stok veya sipariş miktarı
        // OrderLine Entity'sindeki StockQuantity alanına karşılık gelir [3, 4].
        public required decimal Quantity { get; init; }

        // Satış fiyatı
        // OrderLine Entity'sindeki UnitPrice alanına karşılık gelir [3, 4].
        public required decimal UnitPrice { get; init; }

        // (Opsiyonel) Satır bazında ek notlar
        [MaxLength(255)]
        public string? LineNote { get; init; }
    }
}
