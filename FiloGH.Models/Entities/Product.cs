using FiloGH.Models.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public ProductStatus Status { get; set; }
        [MaxLength(255)]
        public required string Title { get; set; }
        public int? VendorId { get; set; }  
        public Vendor? Vendor { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int VatId { get; set; }
        public required Vat Vat { get; set; }
        /// <summary>
        /// Stok Milyem
        /// </summary>
        [Column(TypeName = "decimal(9,3)")] 
        public decimal? FinenessProduct { get; set; }
        /// <summary>
        /// Satış Milyem
        /// </summary>
        [Column(TypeName = "decimal(9,3)")] 
        public decimal? FinenessSelling { get; set; }
        /// <summary>
        /// Has no variant
        /// </summary>
        public bool SingleProduct { get; set; }
        public required ICollection<ProductVariant> Variants { get; set; }
        /// <summary>
        /// Custom product property names like "Size", "Color", and "Material".
        /// Products are based on permutations of these options. 
        /// A product may have a maximum of 3 options. 255 characters limit each.
        /// </summary>
        public ICollection<ProductOption>? Options { get; set; }

        /// <summary>
        /// A list of image objects, each one representing an image associated with the product.
        /// </summary>
        public ICollection<ProductMedia>? Images { get; set; }

        /// <summary>
        /// Birim Stok
        /// </summary>
        public int StockUnitId { get; set; }
        public required Unit StockUnit { get; set; }
        /// <summary>
        /// Birim Cari
        /// </summary>
        public int CustomerUnitId { get; set; }
        public required Unit CustomerUnit { get; set; }
        /// <summary>
        /// Goldschmuck, Silberschmuck, Hurda gibi
        /// </summary>
        public int ProductTypeId { get; set; }
        public required ProductType ProductType { get; set; }
        /// <summary>
        /// Grammware. Değilse stückware
        /// </summary>
        public bool IsPerGramm { get; set; }
        /// <summary>
        /// Adet başına gram. Ziynetlerin adet başına gramı gibi
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] 
        public decimal? WeightPerItem { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public ICollection<CategoryAttribute>? CategoryAttributes { get; set; }
        [MaxLength(255)]
        public string? Tags { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public int CreatedById { get; set; }
        public required User CreatedBy { get; set; }
        public int? UpdatedById { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
