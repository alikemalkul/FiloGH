using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir müşterinin/tedarikçinin (Customer) sahip olduğu metal bakiyelerini gram cinsinden tutar.
    /// </summary>
    public class CustomerMetalAccount
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; } = null!;

        /// <summary>
        /// Bu hesabın tutulduğu metal para birimi (Genellikle XAU, XAG, XPT).
        /// </summary>
        public byte MetalCurrencyId { get; set; }
        public required Currency MetalCurrency { get; set; } = null!;

        /// <summary>
        /// İlgili metalin müşteri hesabındaki anlık toplam bakiyesi (Gram).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal BalanceInGrams { get; set; } = 0.0M;

        public bool IsActive { get; set; } = true;

        public DateTimeOffset LastUpdated { get; set; } = DateTimeOffset.Now;

        // --- İLİŞKİLER ---
        // public ICollection<CustomerMetalAccountTransaction> Transactions { get; set; } // Hareket Detayları
    }
}