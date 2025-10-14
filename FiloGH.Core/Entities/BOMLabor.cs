using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// BillOfMaterials (Reçete) içindeki işçilik, hizmet ve diğer sabit maliyet bileşenlerini tanımlar.
    /// </summary>
    public class BOMLabor
    {
        public int Id { get; set; }

        public int BomId { get; set; }
        public required BillOfMaterials Bom { get; set; } = null!;

        /// <summary>
        /// İşçilik/Giderin türü (Montaj, Cila, Sertifika vb.).
        /// </summary>
        public byte LaborCostTypeId { get; set; }
        public required BOMCostType LaborCostType { get; set; } = null!; // CostType Entity'sine FK

        // --- MALİYET BİLGİLERİ ---

        /// <summary>
        /// Maliyet hesaplaması için kullanılan birim başına miktar (saat, adet vb.).
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// İşçilik/Giderin birim başına maliyeti (Varsayılan Para Birimi cinsinden).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal UnitCost { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }
    }
}