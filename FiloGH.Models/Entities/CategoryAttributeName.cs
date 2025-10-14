using FiloGH.Models.Models.Enum;

namespace FiloGH.Models.Entities
{
    public class CategoryAttributeName
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Category>? ProductCategories { get; set; }
        public ICollection<CategoryAttributeValue>? AttributeValues { get; set; }
        public bool IsRequired { get; set; }
        public InputType InputType { get; set; }
    }
}
