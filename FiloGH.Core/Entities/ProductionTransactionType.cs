using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim Hareketi'nin (ProductionTransaction) türlerini tanımlar (Sarf, Giriş, Fire, vb.).
    /// </summary>
    public class ProductionTransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu hareketin stok envanterini artırıcı (+ True) veya azaltıcı (- False) yönde mi etki ettiğini belirtir.
        /// </summary>
        public bool IsInventoryInflow { get; set; } = false;

        public bool IsActive { get; set; } = true;

        // public ICollection<ProductionTransaction> Transactions { get; set; }
    }
}