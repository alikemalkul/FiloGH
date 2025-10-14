using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        [MaxLength(255)]
        public required string VendorName { get; set; }
    }
}
