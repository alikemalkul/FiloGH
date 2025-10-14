using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Kuyumculuk ERP'sinin envanterindeki tüm fiziksel ve sanal kalemleri (Mamul, Hammadde, Taş) tanımlayan ana Entity.
    /// </summary>
    public class StockItem
    {
        public int Id { get; set; }

        /// <summary>
        /// Ürünün/Kalemin benzersiz stok kodu (SKU).
        /// </summary>
        [MaxLength(50)]
        public required string ItemCode { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // --- STOK TİPİ VE BİRİMİ ---

        public byte StockItemTypeId { get; set; }
        public required StockItemType StockItemType { get; set; } = null!;

        /// <summary>
        /// Stok takibinin yapıldığı ana ölçü birimi (Adet, Gram, Karat).
        /// </summary>
        public byte BaseUnitId { get; set; }
        public required UnitOfMeasure BaseUnit { get; set; } = null!; // ✅ UnitOfMeasure FK

        // --- KUYUMCULUK DETAYLARI ---

        /// <summary>
        /// Kalem değerli metal içeriyor mu?
        /// </summary>
        public bool IsMetalItem { get; set; } = false;

        public byte? MetalTypeId { get; set; }
        public MetalType? MetalType { get; set; } // ✅ MetalType FK

        public byte? MetalPurityId { get; set; }
        public MetalPurity? MetalPurity { get; set; } // ✅ MetalPurity FK
    }
}