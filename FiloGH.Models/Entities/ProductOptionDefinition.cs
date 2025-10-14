using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class ProductOptionDefinition
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public int Position { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }//Renk, Beden..
    }
}
