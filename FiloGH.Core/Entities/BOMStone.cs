using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// BillOfMaterials (Reçete) içindeki bir taş bileşenini tanımlar.
    /// </summary>
    public class BOMStone
    {
        public int Id { get; set; }

        public int BomId { get; set; }
        public required BillOfMaterials Bom { get; set; } = null!;

        public byte StoneTypeId { get; set; }
        public required BOMStoneType StoneType { get; set; } = null!;

        // --- TAŞ ÖZELLİKLERİ ---

        /// <summary>
        /// Taşın boyutu (Genellikle MM). Örn: 1.2, 1.5.
        /// </summary>
        [Column(TypeName = "decimal(4,2)")]
        public decimal StoneSize { get; set; }

        /// <summary>
        /// Bu boyutta kullanılan adet sayısı.
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Reçetede kullanılan toplam Karat ağırlığı (ct).
        /// </summary>
        [Column(TypeName = "decimal(8,4)")]
        public decimal CaratTotal { get; set; }

        // --- MALİYET BİLGİLERİ ---

        /// <summary>
        /// Bu taş için Karat başına standart maliyet (Bu reçete için belirlenir).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPerCarat { get; set; }
    }
}