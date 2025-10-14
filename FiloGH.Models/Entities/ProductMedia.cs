using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class ProductMedia
    {
        public int Id { get; set; }
        public byte Position { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        [MaxLength(255)]
        public string? Alt { get; set; }
        public byte Version { get; set; }
    }
}
