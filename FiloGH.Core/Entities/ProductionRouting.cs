using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Ürünün üretim adımlarının sırasını ve ilgili iş merkezlerini tanımlayan ana rota Entity'si.
    /// </summary>
    public class ProductionRouting
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Code { get; set; }

        [MaxLength(150)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu rotadaki tüm adımların toplam tahmini süresi (Saat).
        /// </summary>
        public short TotalTimeHours { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        // --- İLİŞKİLER ---

        /// <summary>
        /// Rotanın içerisindeki sıralı üretim adımları.
        /// </summary>
        public ICollection<ProductionRoutingStep> Steps { get; set; } = new List<ProductionRoutingStep>(); // Bir sonraki adım
    }
}