using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Müşterilere veya Müşteri Gruplarına uygulanan dinamik fiyatlandırma listesinin ana tanımı.
    /// IEntity arayüzü, Generic Repository'nin doğru çalışması için gereklidir.
    /// ID tipi int olduğu için IEntity<int> kalıtımı eklendi.
    /// </summary>
    public class PriceList : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Fiyat listesinin geçerli olduğu para biriminin FK'sı.
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        /// <summary>
        /// Fiyat listesinin varsayılan birim fiyatı (Satır kuralları yoksa kullanılır).
        /// PriceListDialog.razor'daki hatayı çözmek için eklendi.
        /// </summary>
        [Column(TypeName = "decimal(18, 4)")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Fiyat listesinin açıklaması. PriceListDialog.razor'daki hatayı çözmek için eklendi.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; set; }


        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Fiyat listesinin kullanıldığı minimum/maksimum değerleri veya tarih aralıklarını belirlemek için.
        /// </summary>
        public DateTimeOffset ValidFrom { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidTo { get; set; }

        /// <summary>
        /// Bu fiyat listesinin temel fiyat listesi olup olmadığı (Fiyat kuralı bulunamayan ürünler için yedek).
        /// </summary>
        public bool IsBasePriceList { get; set; } = false;

        // public ICollection<PriceListRule> Rules { get; set; }
        // public ICollection<Customer> Customers { get; set; }
    }
}
