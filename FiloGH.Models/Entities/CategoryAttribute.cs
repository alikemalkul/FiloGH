using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class CategoryAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryAttributeNameId { get; set; }
        public required CategoryAttributeName CategoryAttributeName { get; set; }
        public int? ProductCategoryAttributeValueId { get; set; }
        public CategoryAttributeValue? CategoryAttributeValue { get; set; }
        /// <summary>
        /// If ProductCategoryAttributeValueId not supplied then use this as string value
        /// </summary>
        [MaxLength(255)]
        public string? CategoryCustomValue { get; set; }

    }
}
