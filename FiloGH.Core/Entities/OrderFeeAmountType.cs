using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ek ücret tutarının (Amount) sabit bir değer mi yoksa yüzdesel bir değer mi olduğunu tanımlar.
    /// </summary>
    public class OrderFeeAmountType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; } // Örn: Sabit Tutar, Yüzde

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: FIXED, PERCENT

        public bool IsActive { get; set; } = true;
    }
}