using FiloGH.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir ticari işlemin Borç/Alacak kaydının ana başlık Entity'sidir. (JournalEntry -> AccountingJournalEntry olarak güncellendi)
    /// </summary>
    public class AccountingJournalEntry
    {
        public long Id { get; set; }

        [MaxLength(20)]
        public required string EntryNumber { get; set; }

        public DateTimeOffset EntryDate { get; set; } = DateTimeOffset.Now;

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Fişin defterlere resmi olarak işlenip işlenmediği.
        /// </summary>
        public bool IsPosted { get; set; } = false;

        // --- KAYNAK BELGE İLİŞKİSİ ---

        public int? ReferenceDocumentId { get; set; } // Kaynak belgenin ID'si (Örn: InvoiceId)

        [MaxLength(50)]
        public string? ReferenceDocumentType { get; set; } // Kaynak belgenin tipi (Örn: 'INVOICE', 'ORDER')

        // --- İLİŞKİLER ---

        /// <summary>
        /// Fişin Borç ve Alacak detay satırları.
        /// </summary>
        public ICollection<AccountingJournalEntryLine> Lines { get; set; } = new List<AccountingJournalEntryLine>(); // Bir sonraki adım
    }
}