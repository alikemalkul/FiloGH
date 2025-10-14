using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderFulfillment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public required Order Order { get; set; }
        /// <summary>
        /// Human readable reference identifier for this fulfillment. Such as 1001-F1
        /// </summary>
        [MaxLength(20)]
        public required string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public byte StatusId { get; set; }
        public required OrderStatusDefinition Status { get; set; }
        public int Quantity { get; set; }
        public byte LocationId { get; set; }
        public required Location Location { get; set; }
        public int? ShippingAddressId { get; set; }
        public MailingAddress? ShippingAddress { get; set; }
        public byte? CargoId { get; set; }
        public Cargo? Cargo { get; set; }
        [MaxLength(255)]
        public string? TrackingNumber { get; set; }
        //public ICollection<ShippingLine>? ShippingLines { get; set; }
        //public ICollection<OrderFulfillmentVariant>? FulfillmentVariants { get; set; }
        [Column(TypeName = "decimal(19,2)")]
        public decimal CashOnDeliveryPrice { get; set; }
        public DateTimeOffset PackageControlledAt { get; set; }
        public byte? PackageControlledById { get; set; }
        public User? PackageControlledBy { get; set; }
    }
}
