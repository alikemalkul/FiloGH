using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
