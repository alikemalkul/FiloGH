using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Şirketin veya bir Partnerin (Müşteri/Tedarikçi) banka hesap bilgilerini tutar.
    /// </summary>
    public class Bank
    {
        public int Id { get; set; }

        /// <summary>
        /// Hesap sahibinin adı/ünvanı.
        /// </summary>
        [MaxLength(255)]
        public required string AccountHolderName { get; set; }

        /// <summary>
        /// IBAN numarası.
        /// </summary>
        [MaxLength(34)]
        public required string Iban { get; set; }

        [MaxLength(11)]
        public string? SwiftCode { get; set; }

        /// <summary>
        /// Hesabın para birimi (TRY, EUR, USD, XAU vb.).
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        /// <summary>
        /// Bu hesabın hangi şubeye ait olduğu (Kendi Şirketinin Şubesi)
        /// </summary>
        public byte? BranchId { get; set; }
        public Branch? Branch { get; set; }

        /// <summary>
        /// Bu hesabın Muhasebe Hesap Planındaki karşılığı (Örn: 102 Bankalar Hesabı).
        /// </summary>
        public int AccountChartId { get; set; }
        public required AccountChart AccountChart { get; set; } = null!;

        /// <summary>
        /// Eğer bir Customer/Supplier'a aitse (Müşteri/Tedarikçi Banka Hesabı).
        /// </summary>
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public bool IsActive { get; set; } = true;
    }
}