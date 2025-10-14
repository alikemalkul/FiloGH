using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir İş Emrinin geçmesi gereken tek bir üretim aşamasını (operasyonu) temsil eder.
    /// </summary>
    public class WorkOrderOperation : IEntity<int>
    {
        public int Id { get; set; }

        // --- İLİŞKİLER ---

        /// <summary>
        /// Bu operasyonun ait olduğu ana İş Emri.
        /// </summary>
        public int WorkOrderId { get; set; }
        public required WorkOrder WorkOrder { get; set; } = null!;

        /// <summary>
        /// Gerçekleştirilen operasyonun tanımı (Örn: Döküm, Polisaj, Taş Dizme).
        /// </summary>
        public byte OperationDefinitionId { get; set; }
        public required OperationDefinition OperationDefinition { get; set; } = null!;

        /// <summary>
        /// Operasyonun atandığı iş istasyonu/atölye.
        /// </summary>
        public byte WorkCenterId { get; set; }
        public required WorkCenter WorkCenter { get; set; } = null!;

        public byte StatusId { get; set; }
        public required OperationStatus Status { get; set; } = null!; // (New, In Progress, Complete, On Hold)

        // --- TAKİP BİLGİLERİ ---

        /// <summary>
        /// İş emri rotasındaki bu aşamanın sırası (Örn: 10, 20, 30).
        /// </summary>
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Operasyonun atanma zamanı.
        /// </summary>
        public DateTimeOffset AssignedAt { get; set; }

        /// <summary>
        /// Operasyonun başlatıldığı zaman (Fiili Başlangıç).
        /// </summary>
        public DateTimeOffset? StartedAt { get; set; }

        /// <summary>
        /// Operasyonun tamamlandığı zaman (Fiili Bitiş).
        /// </summary>
        public DateTimeOffset? CompletedAt { get; set; }

        // --- METAL/AĞIRLIK KAYDI ---

        /// <summary>
        /// Bu operasyon başlangıcında istasyona teslim edilen metalin ağırlığı (Örn: Dökümhaneye giren mum + metal).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] 
        public decimal MetalInputWeight { get; set; }

        /// <summary>
        /// Bu operasyon sonunda istasyondan çıkan metalin ağırlığı (Örn: Ağaçtan kesilen takılar).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] 
        public decimal MetalOutputWeight { get; set; }

        /// <summary>
        /// Operasyon sırasında oluşan metal kaybı/firesi (Input - Output).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] 
        public decimal ScrapWeight { get; set; }

        // --- KOLEKSİYONLAR ---

        /// <summary>
        /// Bu operasyon üzerinde çalışan personel ve harcanan zaman kayıtları.
        /// </summary>
        public ICollection<WorkOrderOperationLog>? Logs { get; set; }
    }
}