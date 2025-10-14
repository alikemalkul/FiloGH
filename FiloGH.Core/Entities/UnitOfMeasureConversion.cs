using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// İki farklı ölçü birimi arasındaki çevrim kuralını tanımlar (Örn: Gram'dan Ons'a, Adet'ten Kutu'ya).
    /// </summary>
    public class UnitOfMeasureConversion
    {
        public int Id { get; set; }

        /// <summary>
        /// Dönüşümün yapılacağı kaynak birim (Örn: Gram).
        /// </summary>
        public byte FromUnitId { get; set; }
        public required UnitOfMeasure FromUnit { get; set; } = null!;

        /// <summary>
        /// Dönüşümün yapılacağı hedef birim (Örn: Ons).
        /// </summary>
        public byte ToUnitId { get; set; }
        public required UnitOfMeasure ToUnit { get; set; } = null!;

        /// <summary>
        /// Kaynak birimi hedef birime çevirmek için kullanılan oran. 
        /// Örn: 1 Gram * 0.0321507 = 1 Ons.
        /// </summary>
        [Column(TypeName = "decimal(19,8)")]
        public decimal ConversionRate { get; set; }

        /// <summary>
        /// Çevrimin sadece belirli bir ürüne/ürün grubuna özel olup olmadığı.
        /// </summary>
        public int? ProductVariantId { get; set; }
        public ProductVariant? ProductVariant { get; set; }

        public bool IsActive { get; set; } = true;
    }
}