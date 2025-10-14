using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class OrderTaxLine
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal ShopTaxBaseAmount { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal PresentmentTaxBaseAmount { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal ShopTaxAmount { get; set; }
        [Column(TypeName = "decimal(19,2)")] 
        public decimal PresentmentTaxAmount { get; set; }
        [Column(TypeName = "decimal(9,3)")] 
        public decimal Rate { get; set; }
    }
}
