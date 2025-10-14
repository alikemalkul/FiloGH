using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim operasyonlarının gerçekleştiği fiziksel/mantıksal bir iş istasyonu, makine veya atölye.
    /// </summary>
    public class WorkCenter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// İş Merkezinin kısa kodu (Örn: DKM01, MONTAJ_HATT, CILA_ALAN).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// İş Merkezinin okunabilir adı (Örn: Döküm Makinesi 1, Montaj Atölyesi, Polisaj).
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu iş merkezinin bulunduğu şube veya lokasyon.
        /// </summary>
        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        /// <summary>
        /// İş Merkezinin bir makine mi yoksa genel bir alan mı olduğunu belirtir.
        /// </summary>
        public bool IsMachine { get; set; } = true;

        /// <summary>
        /// Maliyet hesaplamaları için saatlik standart maliyet oranı (TL/USD/EUR cinsinden olabilir).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal HourlyCostRate { get; set; } = 0;

        /// <summary>
        /// İş merkezinin aktif olup olmadığı.
        /// </summary>
        public bool IsActive { get; set; } = true;

        // --- KOLEKSİYONLAR ---

        /// <summary>
        /// Bu iş merkezinde gerçekleştirilmesine izin verilen operasyon türleri.
        /// </summary>
        public ICollection<WorkCenterOperation>? AllowedOperations { get; set; }
    }
}