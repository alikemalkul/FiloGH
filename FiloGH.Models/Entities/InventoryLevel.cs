using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class InventoryLevel
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; }
        public int LocationId { get; set; }
        public required Location Location { get; set; }
        /// <summary>
        /// [incoming state]
        /// What is in transit to this location
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Incoming { get; set; }
        /// <summary>
        /// [on_hand state]
        /// [available state]
        /// The inventory that a merchant can sell. Available inventory isn’t committed to any orders and isn’t part of incoming transfers.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Available { get; set; }
        /// <summary>
        /// [on_hand state]
        /// The number of units that are part of a placed order but aren't fulfilled
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Committed { get; set; }
        /// <summary>
        /// [on_hand state]
        /// [unavailable state]
        /// The on-hand units that are temporarily set aside. For example, a merchant might want to set on-hand units aside for holds or inspection
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Reserved { get; set; }
        /// <summary>
        /// [on_hand state]
        /// [unavailable state]
        /// The on-hand units that aren't sellable or usable due to damage
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Damaged { get; set; }
        /// <summary>
        /// [on_hand state]
        /// [unavailable state]
        /// The on-hand units that are set aside to help guard against overselling
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal SafetyStock { get; set; }
        /// <summary>
        /// [on_hand state]
        /// [unavailable state]
        /// The on-hand units that aren't sellable because they're currently in inspection for quality purposes.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal QualityControl { get; set; }
    }
}
