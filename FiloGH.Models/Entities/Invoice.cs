using FiloGH.Models.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int CustomerId { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public required Customer Customer { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int? InvoiceMetaFieldId { get; set; }//Özel Kod
        public InvoiceMetaField? InvoiceMetaField { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal ShippingCost { get; set; }//Kargo ücreti
        [MaxLength(255)]
        public string? DocumentNumber { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal  OrderAmount { get; set; }
        [MaxLength(255)]
        public string? Note { get; set; }
    }
}
