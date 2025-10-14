using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
