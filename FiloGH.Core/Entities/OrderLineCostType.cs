using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderLineCostType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public bool IsActive { get; set; }
        
        /// <summary>
        /// METAL, LOSS, WORKMANSHIPFEE, PROFIT, DISCOUNT, VAT gibi benzersiz kod.
        /// </summary>
        [MaxLength(20)]
        public required string Code { get; set; } = null!;
        
        /// <summary>
        /// Metal, İşçilik Ücreti, Kâr gibi kullanıcı dostu isim.
        /// </summary>
        public required string Name { get; set; } = null!;

        /// <summary>
        /// Bu maliyet tipinin (Örn: METAL) fiziksel envanter hareketini (StockTransaction) tetikleyip tetiklemediği.
        /// </summary>
        public bool AffectsMetalInventory { get; set; }
        
        /// <summary>
        /// Bu maliyet tipinin, ürünün direkt maliyetini (Cost of Goods Sold - COGS) oluşturup oluşturmadığı. Metal ve İşçilik true iken Kâr ve kdv false olacak
        /// </summary>
        public bool IsCost { get; set; }
        
        public ICollection<OrderLineCost> OrderLineCosts { get; set; } = new List<OrderLineCost>();
    }
}
