using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class MetalPurity : IEntity<byte>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Karat cinsinden değeri (Altın için 8, 14, 18 gibi).
        /// </summary>
        public byte KaratValue { get; set; }

        /// <summary>
        /// Metalin saflık oranı (24K'ya göre oran). Örn: 18K için 0.75.
        /// Fiyat ve has karşılığı hesaplamaları için kritiktir.
        /// </summary>
        [Column(TypeName = "decimal(5,4)")]
        public decimal PurityRatio { get; set; }

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        /// <summary>
        /// Bu ayarın ait olduğu ana metal türü (Altın, Gümüş, Platin).
        /// </summary>
        public byte BaseMetalId { get; set; }
        public required MetalType BaseMetal { get; set; } = null!; // MetalType Entity'sine FK
    }
}