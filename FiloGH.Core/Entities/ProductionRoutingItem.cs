namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir ProductVariant'ın üretimi için hangi ProductionRouting'i kullanacağını tanımlar.
    /// (Bu, ProductVariant ile Routing arasında 1:M veya M:M ilişkiyi kurar.)
    /// </summary>
    public class ProductionRoutingItem
    {
        // Bileşik Anahtar (Composite Key: ProductVariantId ve ProductionRoutingId)

        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        public int ProductionRoutingId { get; set; }
        public required ProductionRouting ProductionRouting { get; set; } = null!;

        /// <summary>
        /// Ürünün hangi amaçla (Üretim, Maliyetlendirme, vb.) bu rotayı kullandığı.
        /// </summary>
        public byte RoutingPurposeId { get; set; }
        public required RoutingPurpose RoutingPurpose { get; set; } = null!; // Varsayımsal bir amaç belirleyici entity

        /// <summary>
        /// Bu, bir ürün için varsayılan üretim rotası mı?
        /// </summary>
        public bool IsDefault { get; set; } = true;
    }
}