using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderAdditionalFeeDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: Standart Kargo, Özel Tasarım Komisyonu

        [MaxLength(20)]
        public required string Code { get; set; }
        public  int  Position { get; set; }
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Ücretin muhasebede işleneceği varsayılan Hesap Planı ID'si (Örn: 602 Diğer Gelirler).
        /// </summary>
        public int DefaultAccountingAccountId { get; set; }
        public required AccountChart DefaultAccountingAccount { get; set; } = null!;
    }
}
