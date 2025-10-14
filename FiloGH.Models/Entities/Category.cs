using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
        public int Position { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category>? SubCategories { get; set; }
        public ICollection<CategoryAttributeName>? AttributeNames { get; set; }

    }
}
