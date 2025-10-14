using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir Order'da metal cinsi (Altın, Gümüş) ve müşteri para birimi (CustomerCurrency) 
    /// bazında toplam ağırlık ve tutar özetini tutar.
    /// </summary>
    public class OrderMetalSummary
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public required Order Order { get; set; } = null!;

        /// <summary>
        /// Hesaplama için baz alınan metal veya döviz (Örn: Altın (XAU), EUR, USD).
        /// </summary>
        public byte CustomerCurrencyId { get; set; }
        public required Currency CustomerCurrency { get; set; } = null!;

        /// <summary>
        /// İlgili metale/dövize ait toplam brüt ağırlık (Gram) veya Adet (Stok/Para Birimi bazında).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalWeightOrAmount { get; set; }

        /// <summary>
        /// İlgili metale ait Karat (ct) cinsinden toplam taş ağırlığı (Opsiyonel).
        /// </summary>
        [Column(TypeName = "decimal(10,4)")]
        public decimal TotalCaratWeight { get; set; } = 0.0M;
    }
}