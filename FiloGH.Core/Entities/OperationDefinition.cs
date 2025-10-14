using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir İş Emrinde gerçekleştirilebilecek temel operasyon türlerinin tanımı.
    /// (Örn: Döküm, Montaj, Taş Dizme, Rodaj, Cila).
    /// </summary>
    public class OperationDefinition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Operasyonun kısa kodu (Örn: CAST, ASSEMB, STONE).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Operasyonun okunabilir adı (Örn: Döküm İşlemi, Montaj Hattı, Taş Dizim).
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu operasyonun genellikle bir iş merkezinde mi (WorkCenter) yoksa tek bir personel tarafından mı yapıldığını belirtir.
        /// </summary>
        public bool RequiresWorkCenter { get; set; } = true;

        /// <summary>
        /// Bu operasyonun kuyumculukta metalin saflığını (purity) değiştiren bir işlem olup olmadığını belirtir (Örn: Döküm).
        /// </summary>
        public bool IsMetalPurityChanging { get; set; } = false;

        /// <summary>
        /// Bu operasyon için tahmini bir standart süre (saat) var mı? (Gelecekteki maliyet hesaplamaları için).
        /// </summary>
        [Column(TypeName = "decimal(19,2)")]
        public decimal StandardDurationHours { get; set; } = 0;

        // --- KOLEKSİYONLAR ---

        /// <summary>
        /// Bu operasyonun uygulanabileceği WorkCenter/İş İstasyonları (Çoktan çoğa ilişki).
        /// </summary>
        public ICollection<WorkCenterOperation>? AllowedWorkCenters { get; set; }
    }
}