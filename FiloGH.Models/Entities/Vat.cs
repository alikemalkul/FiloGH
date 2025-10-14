using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Models.Entities
{
    public class Vat
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int Position { get; set; }
        [MaxLength(255)]
        public required string Name { get; set; }
        /// <summary>
        /// Non comma including Tax rate to display
        /// </summary>
        [MaxLength(255)]
        public required string PresentmentTaxRate { get; set; }
        /// <summary>
        /// The value should be between 0 and 1
        /// </summary>
        [Column(TypeName = "decimal(9,3)")]
        public decimal Rate { get; set; }
    }
}
