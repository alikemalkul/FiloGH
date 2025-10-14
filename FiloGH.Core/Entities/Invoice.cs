using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Hem Satış hem de Alış işlemleri için kullanılan ana fatura belgesi.
    /// </summary>
    public class Invoice
    {
        public int Id { get; set; }

        public byte RootTypeId { get; set; } // EKLEME: Faturanın tipi (Satış/Alış/İade)
        public required RootType RootType { get; set; } = null!;

        [MaxLength(50)]
        public required string InvoiceNumber { get; set; }

        public DateTimeOffset InvoiceDate { get; set; }

        // --- TİCARİ İLİŞKİLER (ÇİFT AMAÇLI) ---

        /// <summary>
        /// Fatura bir satış faturası ise müşteri ID'si.
        /// </summary>
        public int? CustomerId { get; set; } // EKLEME
        public Customer? Customer { get; set; }

        public int? RelatedOrderId { get; set; } // Hangi siparişe kesildiği (SalesOrder veya PurchaseOrder ID'si)
                                                 // public Order? RelatedOrder { get; set; } = null!; // Generic Order'ı kaldırdık/yorumladık

        // --- MUHASEBE VE KUR BİLGİLERİ ---

        /// <summary>
        /// Bu faturadan kaynaklanan muhasebe fişi (Alacak/Borç kaydı için kritik).
        /// </summary>
        public long JournalEntryId { get; set; } // EKLEME
        public required AccountingJournalEntry JournalEntry { get; set; } = null!;

        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        public byte InvoiceStatusId { get; set; }
        public required InvoiceStatus InvoiceStatus { get; set; } = null!;

        [Column(TypeName = "decimal(19,8)")]
        public decimal ExchangeRate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }

        // --- KOLEKSİYONLAR ---

        /// <summary>
        /// Faturaya ait detay satırları (InvoiceLine).
        /// </summary>
        public ICollection<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
        // public ICollection<InvoiceTaxLine> TaxLines { get; set; }
    }
}