using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        /// <summary>
        /// Iso code. Such as TRY, EUR, USD
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }
        [MaxLength(3)]
        public required string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsMetalCurrency { get; set; }
        [Column(TypeName = "decimal(19,3)")]
        public decimal Rate { get; set; }
        public DateTimeOffset? RateUpdatedAt { get; set; }
        /// <summary>
        /// On Currencies: €, $..
        /// </summary>
        [MaxLength(10)]
        public string? Symbol { get; set; }
    }
}
