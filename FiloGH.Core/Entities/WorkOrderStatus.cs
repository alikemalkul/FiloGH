using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// İş Emrinin (Work Order) o anki durumunu tanımlar (Yeni, Üretimde, Tamamlandı, İptal Edildi, vb.).
    /// </summary>
    public class WorkOrderStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Durumun kısa kodu (Örn: NEW, WIP, COMP, CANC).
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Durumun okunabilir adı (Örn: Yeni Oluşturuldu, Üretim Devam Ediyor, Tamamlandı).
        /// </summary>
        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// Bu durumun, iş emrinin üretim sürecinde mi olduğunu gösterir.
        /// (Örn: "WIP" True, "COMP" veya "NEW" False olabilir).
        /// </summary>
        public bool IsInProduction { get; set; } = false;

        /// <summary>
        /// Bu durumdaki iş emrinin düzenlenebilir olup olmadığını belirtir.
        /// </summary>
        public bool IsEditable { get; set; } = true;
    }
}