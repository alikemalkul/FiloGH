using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OwnCompany
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(255)]
        public string? LegalName { get; set; }

        public bool IsActive { get; set; }

        // --- FİNANSAL / YASAL BİLGİLER ---

        [MaxLength(100)]
        public required string TaxOffice { get; set; }

        [MaxLength(20)]
        public required string TaxNumber { get; set; }

        /// <summary>
        /// Tüm kur çevrimlerinin ve muhasebe raporlamasının yapılacağı ana para birimi.
        /// </summary>
        public byte BaseCurrencyId { get; set; }
        public required Currency BaseCurrency { get; set; } = null!;

        // --- ADRES VE İLİŞKİLER ---

        public int? LegalAddressId { get; set; }
        public MailingAddress? LegalAddress { get; set; }

        /// <summary>
        /// Bu ana firmaya bağlı tüm şubeler.
        /// </summary>
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}