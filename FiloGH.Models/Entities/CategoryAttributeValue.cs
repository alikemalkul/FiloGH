using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class CategoryAttributeValue
    {
        public int Id { get; set; }
        public int ProductCategoryAttributeNameId { get; set; }
        public required CategoryAttributeName CategoryAttributeName { get; set; }
        [MaxLength(255)]
        public required string Value { get; set; }
    }
}
