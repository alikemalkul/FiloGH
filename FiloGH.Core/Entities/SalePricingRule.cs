using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir Fiyat Listesi (PriceList) içindeki ürünler için fiyatı dinamik olarak hesaplayan veya belirleyen kural setidir.
    /// </summary>
    public class SalePricingRule
    {
        public int Id { get; set; }

        public int PriceListId { get; set; }
        public required PriceList PriceList { get; set; } = null!;

        [MaxLength(100)]
        public required string Name { get; set; } // Kuralın adı (Örn: Altın + %10 İşçilik)

        /// <summary>
        /// Kuralın önceliği (Düşük sayı = Yüksek öncelik).
        /// </summary>
        public short Priority { get; set; } = 100;

        /// <summary>
        /// Kuralın uygulanacağı ürün varyantı ID'si (Tüm ürünlere uygulanıyorsa null).
        /// </summary>
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        // --- FİYATLANDIRMA MEKANİZMASI ---

        /// <summary>
        /// Fiyatlandırma tipi: FIXED (Sabit Fiyat), COST_PLUS (Maliyet + Marj), FORMULA (Formül ile hesaplanan).
        /// </summary>
        [MaxLength(20)]
        public required string RuleType { get; set; }

        /// <summary>
        /// Eğer RuleType FIXED ise kullanılan sabit fiyat.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal? FixedPrice { get; set; }

        /// <summary>
        /// Eğer RuleType COST_PLUS veya FORMULA ise kullanılan marj veya çarpan (Örn: 1.10 = %10 kâr marjı).
        /// </summary>
        [Column(TypeName = "decimal(10,5)")]
        public decimal? CalculationValue { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset ValidFrom { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ValidTo { get; set; }
    }
}