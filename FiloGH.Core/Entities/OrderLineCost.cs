using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderLineCost
    {
        public int Id { get; set; }
        public int OrderLineId { get; set; }
        public required OrderLine OrderLine { get; set; } = null!;
        public byte OrderLineCostTypeId { get; set; }
        public required OrderLineCostType OrderLineCostType { get; set; } = null!; // METAL, LOSS, PROFIT, WORKMANSHIPFEE

        /// <summary>
        /// Sadece OrderLineCostType 'METAL' ise kullanılır. Metalin saflık derecesi.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] // Hassasiyet artırıldı
        public decimal? Fineness { get; set; }

        /// <summary>
        /// Bu maliyet bileşeninin tutarı (Örn: Metalin Alış Maliyeti veya İşçilik Tutarı).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] // Hassasiyet artırıldı
        public decimal? Amount { get; set; }

        /// <summary>
        /// Müşteriye uygulanan kur/oran. (Örn: Eğer Metal maliyeti EUR, satış USD ise buradaki çevrim kuru).
        /// </summary>
        [Column(TypeName = "decimal(19,8)")] // Hassasiyet artırıldı
        public decimal? CustomerRate { get; set; }

        /// <summary>
        /// Müşteriye yansıtılan tutar (Örn: Müşteri para biriminde kâr miktarı).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] // Hassasiyet artırıldı
        public decimal? CustomerAmount { get; set; }

        /// <summary>
        /// Bu maliyet bileşeninin para birimi (Örn: Altın (XAU), İşçilik (TRY)).
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;
    }
}
