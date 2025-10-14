using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir stok kaleminin veya OrderLine'ın maliyetini (COGS - Satılan Malların Maliyeti) tutar.
    /// Metal, işçilik ve diğer bileşenlerin maliyetlendirme sonuçlarını saklar.
    /// </summary>
    public class InventoryCost
    {
        public int Id { get; set; }

        /// <summary>
        /// Maliyetin hangi stok kalemine ait olduğu (Optional: Eğer OrderLine üzerinden maliyet takip ediliyorsa).
        /// </summary>
        public int? StockItemId { get; set; }
        public StockItem? StockItem { get; set; }

        /// <summary>
        /// Maliyetin hangi sipariş satırına ait olduğu (Kritik: OrderLine.cs'deki referans için).
        /// </summary>
        public int? OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }

        /// <summary>
        /// Maliyetin hesaplandığı temel para birimi.
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        /// <summary>
        /// Ürünün net metal maliyeti (saf metal ağırlığına göre hesaplanan).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal MetalCost { get; set; } = 0.0M;

        /// <summary>
        /// İşçilik (Workmanship) maliyeti.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal WorkmanshipCost { get; set; } = 0.0M;

        /// <summary>
        /// Diğer sabit/değişken maliyetler (Taş, Kaplama, Ambalaj vb.).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal OtherCosts { get; set; } = 0.0M;

        /// <summary>
        /// Ürünün toplam birim maliyeti.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalUnitCost { get; set; } = 0.0M;

        public DateTimeOffset CalculatedAt { get; set; } = DateTimeOffset.Now;
    }
}