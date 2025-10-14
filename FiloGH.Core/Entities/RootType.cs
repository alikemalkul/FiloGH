using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Order Entity'sinin doğasını (Satış, Satın Alma, İade, Taslak vb.) tanımlar.
    /// </summary>
    public class RootType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: Satış Siparişi, Satın Alma Siparişi

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: SALE, PURCHASE, DRAFT

        /// <summary>
        /// Bu RootType'ın stok hareketine etkisini belirler. 
        /// +1: Stoğa Giriş (Satın Alma)
        /// -1: Stoktan Çıkış (Satış)
        /// 0: Etkisiz (Taslak, Muhasebe Düzeltmesi)
        /// </summary>
        public short StockMovementSign { get; set; }

        public bool IsActive { get; set; } = true;
    }
}