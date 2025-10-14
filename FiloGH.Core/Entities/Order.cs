using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilen benzersiz sipariş numarası (Örn: S-2025-0001).
        /// </summary>
        [MaxLength(50)]
        public required string OrderNumber { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        /// <summary>
        /// Müşterinin istediği teslim tarihi (Satış siparişi ise).
        /// </summary>
        public DateTimeOffset? RequiredDate { get; set; }

        /// <summary>
        /// Tedarikçiden beklenen teslim tarihi (Satın alma siparişi ise).
        /// </summary>
        public DateTimeOffset? ExpectedDate { get; set; }
        /// <summary>
        /// Müşteriye verilen tahmini teslimat tarihi.
        /// </summary>
        public DateTimeOffset? DeliveryDateTarget { get; set; }

        // --- TİCARİ İLİŞKİLER ---

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // --- DURUM VE MUHASEBE ---

        /// <summary>
        /// Siparişin yasal faturalandırma için baz alınacak dövizi (Örn: EUR).
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        public byte StatusId { get; set; }
        public required OrderStatusDefinition Status { get; set; } = null!;

        public byte OrderPaymentStatusId { get; set; }
        public required OrderPaymentStatus OrderPaymentStatus { get; set; } = null!;

        // --- FATURA İLİŞKİSİ ---
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; } // Order'dan Invoice'a tekil (One-to-One) ilişki

        // --- AUDIT VE DİĞER ALANLAR ---
        public ICollection<OrderLine>? OrderLines { get; set; }
        public ICollection<OrderMetalSummary>? MetalSummaries { get; set; }
        public ICollection<OrderAdditionalFee>? AdditionalFees { get; set; }
        public ICollection<OrderTaxLine>? TaxLines { get; set; }
        public ICollection<OrderPaymentLine>? PaymentLines { get; set; }
        public ICollection<OrderFulfillment>? Fulfillments { get; set; }

        // --- AUDIT VE DİĞER ALANLAR ---
        public byte CreatedById { get; set; }
        public required User CreatedBy { get; set; }
        public byte? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? ClosedAt { get; set; }
        public bool TaxesIncluded { get; set; }
        [MaxLength(255)]
        public string? Note { get; set; }
        public int? ShippingAddressId { get; set; }
        public MailingAddress? ShippingAddress { get; set; }
        public int? BillingAddressId { get; set; }
        public MailingAddress? BillingAddress { get; set; }
        public byte RootTypeId { get; set; }
        public required RootType RootType { get; set; } = null!; // SALE, PURCHASE, TRANSFER
        [MaxLength(255)]
        public string? Tags { get; set; }
    }
}