using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public int ProductId { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public required Product Product { get; set; }
        public int Barcode { get; set; }
        public ICollection<InventoryLevel>? InventoryLevels { get; set; }
        public int? Option1Id { get; set; }
        public ProductOptionDefinition? Option1 { get; set; }
        public int? Option2Id { get; set; }
        public ProductOptionDefinition? Option2 { get; set; }
        public int? Option3Id { get; set; }
        public ProductOptionDefinition? Option3 { get; set; }
        public int CaratId { get; set; }
        public required Carat Carat { get; set; }
        /// <summary>
        /// A unique identifier for the product in the shop. Max-length: 50
        /// </summary>
        [MaxLength(50)]
        public string? Sku { get; set; }
        /// <summary>
        /// İlave açıklama, brillant çapı gibi, uzunluk, genişlik gibi
        /// </summary>
        [MaxLength(255)]
        public string? Description { get; set; }

        /// <summary>
        /// The order of the product variant in the list of product variants. 1 is the first position.
        /// </summary>
        public byte Position { get; set; }

        /// <summary>
        /// Specifies whether or not customers are allowed to place an order for a product variant when it's out of stock.
        /// </summary>
        public bool AllowNegativeQuantity { get; set; }

        /// <summary>
        /// Specifies whether or not the quantity of items in stock for this product variant should be tracked.
        /// </summary>
        public bool TrackInventory { get; set; }

        /// <summary>
        /// The buy price for this item.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")]
        public decimal? CostPrice { get; set; }

        /// <summary>
        /// The price of the product variant.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal Price { get; set; }

        /// <summary>
        /// The competitors prices for the same item.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal? CompareAtPrice { get; set; }

        [Column(TypeName = "decimal(19,2)")] 
        public decimal? Gramm { get; set; } 
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int? ImageId { get; set; }
        public ProductMedia? Image { get; set; }
    }
}
