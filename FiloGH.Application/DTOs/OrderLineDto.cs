namespace FiloGH.Application.DTOs
{
    // Sipariş Satırı için veri taşıma nesnesi
    public class OrderLineDto
    {
        public int ProductVariantId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; } // Ekledik
    }
}