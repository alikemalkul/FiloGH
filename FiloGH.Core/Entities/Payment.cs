using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Nakit, banka, çek vb. tüm ödeme ve tahsilat hareketlerini kaydeder ve ilgili muhasebe fişine bağlar.
    /// </summary>
    public class Payment
    {
        public long Id { get; set; }

        [MaxLength(20)]
        public required string PaymentNumber { get; set; }

        public DateTimeOffset PaymentDate { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// İşlemin Tahsilat (True) mı yoksa Ödeme (False) mı olduğunu belirtir.
        /// </summary>
        public bool IsIncoming { get; set; }

        public byte PaymentTypeId { get; set; }
        public required PaymentType PaymentType { get; set; } = null!; // Yeni Entity

        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Paranın çıktığı veya girdiği Banka/Kasa hesabı (Hesap Planında 100 veya 102 ile başlayanlar olmalı).
        /// </summary>
        public int AccountId { get; set; }
        public required AccountChart Account { get; set; } = null!;

        /// <summary>
        /// Bu ödeme hareketini temsil eden muhasebe fişi.
        /// </summary>
        public long JournalEntryId { get; set; }
        public required AccountingJournalEntry JournalEntry { get; set; } = null!;

        // --- İLİŞKİLİ BELGE ---

        public int? ReferenceDocumentId { get; set; } // Örn: Fatura ID'si

        [MaxLength(50)]
        public string? ReferenceDocumentType { get; set; } // Örn: 'INVOICE', 'ORDER'
    }
}