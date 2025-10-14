using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FiloGH.Core.Interfaces; // IEntity için using eklenmeli

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Üretim talebini, metal takibini ve operasyon takibini yöneten temel entite.
    /// </summary>
    // KRİTİK DÜZELTME: IEntity<int> arayüzü uygulandı.
    public class WorkOrder : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilen benzersiz İş Emri Numarası (Örn: WO-2025-0001).
        /// </summary>
        [MaxLength(50)]
        public required string WorkOrderNumber { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// İş emrinin hedeflenen tamamlanma tarihi.
        /// </summary>
        public DateTimeOffset DueDate { get; set; }

        // --- İLİŞKİLER ---

        /// <summary>
        /// Bu iş emrinin hangi Satış Siparişinden geldiği. (Opsiyonel: Üretim talebi stok için de olabilir)
        /// </summary>
        public int? OrderId { get; set; }
        public Order? Order { get; set; }

        /// <summary>
        /// Üretilecek ürünün hangi varyantı (Örn: Yüzük, 14K, Beyaz Altın, 9 No).
        /// </summary>
        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        public byte StatusId { get; set; }
        public required WorkOrderStatus Status { get; set; } = null!; // Üretim Aşaması (New, In Progress, Completed, Canceled)

        public byte CreatedById { get; set; }
        public required User CreatedBy { get; set; } = null!;

        // --- MİKTAR ve METAL BİLGİLERİ ---

        /// <summary>
        /// Üretilecek nihai ürün adedi.
        /// </summary>
        [Column(TypeName = "decimal(19,2)")] public decimal Quantity { get; set; }

        /// <summary>
        /// Üretim için gereken (target) ham metal miktarı (Örn: gram/ağırlık).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal TargetMetalWeight { get; set; }

        /// <summary>
        /// Üretim sürecine fiilen verilen ham metal miktarı (Örn: Dökümhaneye giren metal).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal IssuedMetalWeight { get; set; }

        /// <summary>
        /// İş Emri tamamlandığında sistemin hesapladığı toplam fire (kayıp) miktarı.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal CalculatedScrapWeight { get; set; }

        // --- KOLEKSİYONLAR (Rota ve Operasyonlar) ---

        /// <summary>
        /// İş emrine bağlı operasyonların/aşamaların sırası ve durumu.
        /// </summary>
        public ICollection<WorkOrderOperation>? Operations { get; set; }
    }
}
