using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderPaymentLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; }
        [Column(TypeName = "decimal(19,2)")]
        public decimal Amount { get; set; }
        public required Currency Currency { get; set; }
        public int? BankId { get; set; }
        public Bank? Bank { get; set; }
        public int? CashId { get; set; }
        public Cash? Cash { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTimeOffset Date { get; set; }
        public byte CreatedById { get; set; }
        public required User CreatedBy { get; set; }
        [MaxLength(255)]
        public string? TransactionNr { get; set; }
        [MaxLength(255)]
        public string? Note { get; set; }
    }
}
