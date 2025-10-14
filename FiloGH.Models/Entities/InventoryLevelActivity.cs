using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class InventoryLevelActivity
    {
        public int Id { get; set; }
        //Order Created, Order Fulfilled, Manually adjusted, Items restocked .. gibi eklersin AppDbContext e
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
