using FiloGH.Core.Enums;
using FiloGH.Core.Interfaces; // Gerekli arayüzü ekledik
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    // CS0311 Hatası Çözümü: IEntity<byte> arayüzünü uyguluyoruz.
    public class Currency : IEntity<byte>
    {
        [Key] // Primary Key olarak işaretlendi
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// ISO Kodu (TRY, EUR, USD, XAU, XAG vb.)
        /// </summary>
        [MaxLength(5)]
        public required string Code { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Currency symbol. Such as €, $, ₺
        /// </summary>
        [MaxLength(10)]
        public string? Symbol { get; set; }

        /// <summary>
        /// Para biriminin türünü belirtir (Fiat veya Metal).
        /// </summary>
        // Orijinal yapınızı koruduk: Enum kullanılıyor.
        public CurrencyType Type { get; set; }

        /// <summary>
        /// Uygulamanın genel varsayılan para birimi olup olmadığını belirtir (Örn: EUR).
        /// </summary>
        public bool IsSystemDefault { get; set; }

        /// <summary>
        /// True ise, sistem (Örn: IExternalRateService) bu para birimi/metalin kurunu 
        /// günlük olarak otomatik çekmeli ve DailyRate tablosuna kaydetmelidir.
        /// </summary>
        public bool IsRateTracked { get; set; }

        // Gerekli değil: ICollection<DailyRate> vs. eklenebilir.
    }
}
