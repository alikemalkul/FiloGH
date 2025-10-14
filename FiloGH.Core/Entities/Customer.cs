using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Tüm Ticari Partnerleri (Bireysel Müşteri, Tedarikçi, B2B Partner) tek bir çatı altında tutar.
    /// </summary>
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Müşterinin/Partnerin benzersiz kısa kodu.
        /// </summary>
        [MaxLength(20)]
        public required string PartnerCode { get; set; } // ✅ Yeni Eklendi

        /// <summary>
        /// Müşterinin/Firmanın Adı (Birey ise Ad Soyad).
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // --- ROL BAYRAKLARI (Üç Rolün Yönetimi) ---
        public bool IsSupplier { get; set; }
        public bool IsB2BPartner { get; set; }
        public bool IsCustomer { get; set; }

        // --- FİNANSAL / YASAL BİLGİLER ---
        [MaxLength(20)]
        public string? TaxNumber { get; set; }

        public byte? DefaultCurrencyId { get; set; }
        public Currency? DefaultCurrency { get; set; }

        public byte? PaymentTermId { get; set; }
        public PaymentTerm? PaymentTerm { get; set; }

        // --- ADRES VE İLİŞKİLER ---

        public int? ShippingAddressId { get; set; }
        public MailingAddress? ShippingAddress { get; set; }

        public int? BillingAddressId { get; set; }
        public MailingAddress? BillingAddress { get; set; }

        // --- KUYUMCULUK ÖZEL KOLEKSİYONLAR ---

        // public ICollection<CustomerMetalAccount> MetalAccounts { get; set; } // Metal hesapları
        // public ICollection<Order> Orders { get; set; } 
    }
}