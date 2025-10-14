// FiloGH.Core/Entities/PaymentTerm.cs (Nihai Yapı)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ticari partnerlerle (Customer/Supplier) yapılan anlaşmaların ödeme vadelerini tanımlar.
    /// </summary>
    public class PaymentTerm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Vade sayısı az olacağı için byte yeterlidir.

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: NET30, PESHIN

        [MaxLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Fatura kesim tarihinden itibaren ödeme vadesinin kaç gün sonra olduğunu belirtir.
        /// (Peşin için 0, 30 gün için 30)
        /// </summary>
        public short DueDateDays { get; set; } // short optimizasyonu

        [MaxLength(500)]
        public string? Description { get; set; }

        // --- İLİŞKİLER (Navigation properties) ---
        // Yorum satırları, temiz kod için korunmuştur.
    }
}