using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//migration komutları: 
//Ekleme: dotnet ef migrations add AddedProductionAndInventoryEntities -p FiloGH.Infrastructure -s FiloGH
//Silme: dotnet ef migrations remove -p FiloGH.Infrastructure -s FiloGH

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir İş Emri Operasyonu üzerinde gerçekleştirilen işçilik zamanı, metal girişi/çıkışı ve personel kaydı.
    /// </summary>
    public class WorkOrderOperationLog
    {
        public int Id { get; set; }

        // --- İLİŞKİLER ---

        /// <summary>
        /// Bu log kaydının ait olduğu İş Emri Operasyonu (Ana Adım).
        /// </summary>
        public int OperationId { get; set; }
        public required WorkOrderOperation Operation { get; set; } = null!;

        /// <summary>
        /// Bu kaydı oluşturan veya işi gerçekleştiren personel.
        /// </summary>
        public byte EmployeeId { get; set; }
        public required User Employee { get; set; } = null!; // User entitesini kullanıyoruz

        // --- ZAMAN KAYDI ---

        /// <summary>
        /// Çalışanın işe başladığı fiili zaman (Punch-in).
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Çalışanın işi bitirdiği/durdurduğu fiili zaman (Punch-out). Null olabilir (hala çalışıyorsa).
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Hesaplanan toplam işçilik süresi (dakika). (EndTime - StartTime)
        /// </summary>
        public int DurationMinutes { get; set; }

        // --- METAL/HATA KAYDI ---

        /// <summary>
        /// Operasyon sırasında eklenen veya çıkarılan metal miktarı (Örn: Tamir için eklenen metal, Fire).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] 
        public decimal MetalAdjustmentWeight { get; set; } = 0;

        /// <summary>
        /// MetalAdjustmentWeight'in türü (ADD: Ekleme, SCRAP: Fire/Kayıp).
        /// </summary>
        [MaxLength(10)]
        public string? AdjustmentType { get; set; } // Örn: ADD, SCRAP

        /// <summary>
        /// Log kaydına ilişkin kısa notlar veya hata açıklaması.
        /// </summary>
        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}