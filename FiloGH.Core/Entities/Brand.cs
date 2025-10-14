using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürünlerin (Product) ait olduğu markaları tanımlar.
    /// </summary>
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(150)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public string? Code { get; set; } // Hızlı arama kodu

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<Product> Products { get; set; }
    }
}