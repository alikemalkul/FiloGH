using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Carat
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }

    }
}
