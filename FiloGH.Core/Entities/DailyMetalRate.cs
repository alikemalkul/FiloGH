using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    // FiloGH.Core/Entities/DailyRate.cs

    public class DailyMetalRate
    {
        public int Id { get; set; }

        public DateOnly RateDate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal UsdRate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal TryRate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal GoldBuyRate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal SilverBuyRate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal PlatinumBuyRate { get; set; }

        [Column(TypeName = "decimal(9,4)")]
        public decimal PalladiumBuyRate { get; set; }
    }
}
