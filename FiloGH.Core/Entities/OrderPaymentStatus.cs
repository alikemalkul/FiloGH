using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderPaymentStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Raporlama ve iş akışı için durumun sıralaması (Örn: Ödeme Bekliyor=1, Ödendi=3).
        /// </summary>
        public byte Position { get; set; } = 1;

        /// <summary>
        /// Ödeme durumunun nihai ve geri döndürülemez olup olmadığı (Örn: Ödendi).
        /// </summary>
        public bool IsFinal { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}
