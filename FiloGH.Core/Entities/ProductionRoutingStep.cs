using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir rotanın içerisindeki sıralı adımları ve hangi iş merkezini kullandığını tanımlar.
    /// </summary>
    public class ProductionRoutingStep
    {
        public int Id { get; set; }

        public int RoutingId { get; set; }
        public required ProductionRouting Routing { get; set; } = null!;

        /// <summary>
        /// Adımın sırası (Genellikle 10'ar artan sıra kullanılır: 10, 20, 30...).
        /// </summary>
        public short Sequence { get; set; }

        public byte WorkCenterId { get; set; }
        public required ProductionWorkCenter WorkCenter { get; set; } = null!;

        /// <summary>
        /// Bu adımın iş merkezinde tahmini olarak gerektirdiği süre (Saat).
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal TimeRequiredHours { get; set; }

        /// <summary>
        /// İş merkezinin bir saatlik çalışmasının maliyeti (Maliyetlendirme için).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPerHour { get; set; } = 0.0M;

        public bool IsInspectionStep { get; set; } = false;

        [MaxLength(500)]
        public string? Instructions { get; set; }
    }
}