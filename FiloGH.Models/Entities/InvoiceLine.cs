using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public int? OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }

        [MaxLength(255)]
        public string? AlternateTitle { get; set; }
        [MaxLength(255)]
        public string? Carat { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(2,2)")]
        public decimal DiscountRate { get; set; }
        [Column(TypeName = "decimal(9,2)")] 
        public decimal DiscountAmount { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(2,2)")] 
        public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal TaxBaseAmount { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal TaxAmount { get; set; }
    }
}
