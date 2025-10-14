// FiloGH.Core/Entities/MailingAddress.cs (Nihai ve Kaydedilmiş Yapı)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class MailingAddress
    {
        public int Id { get; set; }

        // --- İLİŞKİLER ---

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // --- ADRES DETAYLARI ---

        [MaxLength(255)]
        public required string Address1 { get; set; }
        [MaxLength(255)]
        public string? Address2 { get; set; }

        [MaxLength(10)] // Yeni Eklendi (Posta Kodu)
        public string? ZipCode { get; set; }

        public byte? CityId { get; set; }
        public City? City { get; set; }
        public byte CountryId { get; set; }
        public required Country Country { get; set; }

        // --- İLETİŞİM KİŞİSİ VE ŞİRKET ---

        [MaxLength(255)]
        public required string FirstName { get; set; }
        [MaxLength(255)]
        public required string LastName { get; set; }

        [MaxLength(255)] // Yeni Eklendi (Firma Adı)
        public string? CompanyName { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        /// <summary>
        /// Bağlı olduğu Customer için varsayılan adres olup olmadığı.
        /// </summary>
        public bool IsPrimary { get; set; } = false; 

        // --- TERS İLİŞKİLER ---

        [InverseProperty("ShippingAddress")]
        public ICollection<Order>? ShippingForOrders { get; set; }

        [InverseProperty("ShippingAddress")]
        public ICollection<OrderFulfillment>? ShippingForFulfillments { get; set; }
    }
}