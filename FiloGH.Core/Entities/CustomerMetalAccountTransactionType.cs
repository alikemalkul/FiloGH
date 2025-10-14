using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{    
    /// <summary>
     /// Finansal ve Stok işlemlerinin türünü (Satış, Satın Alma, Transfer, Has Geri Alma, vb.) tanımlar.
     /// </summary>
    public class CustomerMetalAccountTransactionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: SALE, PURCHASE, METAL_DEPOSIT

        /// <summary>
        /// Bu işlem tipinin stok/metal hareketine etkisini belirler.
        /// +1: Giriş, -1: Çıkış, 0: Etkisiz
        /// </summary>
        public short MovementSign { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
}
