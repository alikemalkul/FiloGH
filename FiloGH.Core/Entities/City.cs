using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Şehir/il sayısı az olacağı için byte yeterlidir.

        [MaxLength(100)]
        public required string Name { get; set; } = null!;

        /// <summary>
        /// Ülke içindeki resmi bölge kodu veya plakası (Opsiyonel).
        /// </summary>
        [MaxLength(10)]
        public string? Code { get; set; }

        // --- İLİŞKİLER ---

        public byte CountryId { get; set; }
        public required Country Country { get; set; } = null!;

        // public ICollection<MailingAddress> Addresses { get; set; }
    }
}