using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class InventoryCost
    {
        public int Id { get; set; }
        public int OrderLineId { get; set; }
        public required OrderLine OrderLine { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal? MetalAmount { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal? LossAmount { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal? WorkmanshipFeeAmount { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal? ProfitAmount { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal? VatAmount { get; set; }
        public byte MetalCurrencyId { get; set; }
        public Currency MetalCurrency { get; set; } = null!;//Loss(Fire) de bu Currency i kullanıyor
        public byte WorkmanshipFeeCurrencyId { get; set; }
        public Currency WorkmanshipFeeCurrency { get; set; } = null!;
        public byte ProfitCurrencyId { get; set; }
        public Currency ProfitCurrency { get; set; } = null!;
        public byte VatCurrencyId { get; set; }
        public Currency VatCurrency { get; set; } = null!;
    }
}
