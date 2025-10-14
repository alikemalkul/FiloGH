using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class InventoryLevelHistory
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; }
        public int LocationId { get; set; }
        public required Location Location { get; set; }
        public int InventoryLevelActivityId { get; set; }
        public required InventoryLevelActivity InventoryLevelActivity { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public DateTimeOffset Date { get; set; }
        public int CreatedById { get; set; }
        public required User CreatedBy { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Incoming { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Available { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Committed { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Reserved { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Damaged { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal SafetyStock { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal QualityControl { get; set; }
    }
}
