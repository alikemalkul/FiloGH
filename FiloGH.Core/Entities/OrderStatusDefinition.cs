using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderStatusDefinition
    {
        /// <summary>
        /// 1-Sipariş Alındı
        /// 2-Firmaya sipariş verildi
        /// 3-Firmadan geldi
        /// 4-Müşteriye gönderildi
        /// 5-Müşteriye Kısmi Teslim
        /// 6-Durduruldu
        /// 7-
        /// 8-Draft Order
        /// 9-İptal Edildi
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Raporlama ve iş akışı için durumun sıralaması (Küçükten büyüğe).
        /// </summary>
        public byte Position { get; set; } = 1; // ✅ Position olarak güncellendi

        /// <summary>
        /// Siparişin bu durumdayken değiştirilip değiştirilemeyeceği.
        /// </summary>
        public bool AllowsChanges { get; set; } = true;

        /// <summary>
        /// Durumun nihai ve geri döndürülemez olup olmadığı (Örn: Teslim Edildi, İptal Edildi).
        /// </summary>
        public bool IsFinal { get; set; } = false;

        public bool IsActive { get; set; } = true;
        //public ICollection<Order>? Orders { get; set; }

        //public ICollection<OrderFulfillment>? OrderFulfillments { get; set; }
    }
}
