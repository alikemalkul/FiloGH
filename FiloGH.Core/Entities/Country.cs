using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// UPPERCASE ISO 3166-1 Alpha-2 kodu. Örn: TR, US.
        /// </summary>
        [MaxLength(2)]
        public required string Code { get; set; } = null!;

        [MaxLength(100)]
        public required string Name { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Bu ülkenin şehir/il isimlerinin önceden tanımlanıp tanımlanmadığı (City tablosu kullanılıp kullanılmayacağı).
        /// </summary>
        public bool HasPredefinedCityNames { get; set; }

        /// <summary>
        /// Ülkenin varsayılan yasal para birimi ID'si.
        /// </summary>
        public byte? DefaultCurrencyId { get; set; }
        public Currency? DefaultCurrency { get; set; }

        // --- İLİŞKİLER ---
        public ICollection<City> Cities { get; set; } = new List<City>();
        // public ICollection<MailingAddress> Addresses { get; set; }
    }
}