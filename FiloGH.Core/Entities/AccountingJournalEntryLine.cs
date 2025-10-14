using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir muhasebe fişindeki (AccountingJournalEntry) her bir Borç veya Alacak hareketini tutar.
    /// </summary>
    public class AccountingJournalEntryLine
    {
        public long Id { get; set; }

        public long EntryId { get; set; }
        public required AccountingJournalEntry Entry { get; set; } = null!;

        public short LineNumber { get; set; }

        /// <summary>
        /// Etkilenen Hesap Planı hesabı.
        /// </summary>
        public int AccountId { get; set; }
        public required AccountChart Account { get; set; } = null!;

        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        [MaxLength(255)]
        public string? Description { get; set; }

        // --- MİKTARLAR ---

        [Column(TypeName = "decimal(18,4)")]
        public decimal DebitAmount { get; set; } = 0.0M;

        [Column(TypeName = "decimal(18,4)")]
        public decimal CreditAmount { get; set; } = 0.0M;

        /// <summary>
        /// Ana Para Birimi cinsinden Borç miktarı (Konsolide raporlama için kritik).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal BaseCurrencyDebit { get; set; } = 0.0M;

        /// <summary>
        /// Ana Para Birimi cinsinden Alacak miktarı (Konsolide raporlama için kritik).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal BaseCurrencyCredit { get; set; } = 0.0M;
    }
}