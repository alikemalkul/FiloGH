using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Stok hareketinin nedenini (Giriş/Çıkış) ve muhasebe etkisini belirler. (Satış, Satın Alma, Fire, Sayım, Transfer vb.)
    /// </summary>
    public class InventoryTransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; } // SALEOUT, PURCHASEIN, LOSS, TRANSFER

        /// <summary>
        /// Hareketin stok miktarını nasıl etkilediği. (+1: Giriş, -1: Çıkış)
        /// </summary>
        public short MovementSign { get; set; } = 1;

        /// <summary>
        /// Bu hareketin ortalama stok maliyetini (Moving Average Cost) değiştirip değiştirmediği.
        /// </summary>
        public bool AffectsCost { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}