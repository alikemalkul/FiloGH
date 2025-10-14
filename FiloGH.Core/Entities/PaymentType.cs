using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ödeme ve tahsilat hareketlerinin (Payment) türlerini tanımlar (Nakit, Banka, Çek vb.).
    /// </summary>
    public class PaymentType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<Payment> Payments { get; set; }
    }
}