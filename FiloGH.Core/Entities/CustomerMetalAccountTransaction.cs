using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Müşterinin (veya Tedarikçinin) has metal (altın, gümüş vb.) hesabındaki giriş/çıkış hareketlerini izler.
    /// </summary>
    public class CustomerMetalAccountTransaction
    {
        public long Id { get; set; } // İşlem hacmi yüksek olabilir

        public DateTimeOffset TransactionDate { get; set; } = DateTimeOffset.Now;

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; } = null!;

        public byte MetalCurrencyId { get; set; }
        public required Currency MetalCurrency { get; set; } = null!; // Altın (XAU), Gümüş (XAG) gibi

        public byte TransactionTypeId { get; set; }
        public required CustomerMetalAccountTransactionType TransactionType { get; set; } = null!;
        /// <summary>
        /// İşlem miktarı (Gram). Pozitif = Giriş (Müşteriden alındı), Negatif = Çıkış (Müşteriye verildi).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal WeightGrams { get; set; }

        /// <summary>
        /// İşlemin bağlandığı ana belge (Örn: Order.Id veya Invoice.Id).
        /// </summary>
        public int? RelatedDocumentId { get; set; }

        [MaxLength(255)]
        public string? Notes { get; set; }
    }
}