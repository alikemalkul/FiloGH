using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir İş Emri Operasyonunun (WorkOrderOperation) o anki durumunu tanımlar.
    /// (Örn: Atandı, Başlatıldı, Tamamlandı, Beklemede, vb.).
    /// </summary>
    public class OperationStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Durumun kısa kodu (Örn: ASSIGN, START, COMP, HOLD).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Durumun okunabilir adı (Örn: Operasyon Atandı, Üretime Başlandı, Tamamlandı).
        /// </summary>
        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu durumdaki operasyonun aktif olarak devam edip etmediğini belirtir.
        /// (Örn: "START" True, "COMP" veya "HOLD" False olabilir).
        /// </summary>
        public bool IsActive { get; set; } = false;

        /// <summary>
        /// Operasyon bu durumdayken, çalışana zaman kaydı girmesine izin verilip verilmediğini belirtir.
        /// </summary>
        public bool AllowTimeEntry { get; set; } = false;
    }
}