using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir ProductVariant'ın üretilmesi için gereken tüm bileşen ve süreçleri tanımlayan üst düzey reçete.
    /// Kuyumculuğa özel net metal ağırlığı ve fire oranı detaylarını içerir.
    /// </summary>
    public class BillOfMaterials
    {
        public int Id { get; set; }

        public int ProductVariantId { get; set; }
        public required ProductVariant ProductVariant { get; set; } = null!;

        [MaxLength(255)]
        public required string Name { get; set; } // Reçetenin adı

        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public required string RevisionNumber { get; set; } = "1.0"; // Versiyon Takibi

        public bool IsActive { get; set; } = true;

        // --- KUYUMCULUK METAL BİLGİLERİ ---

        /// <summary>
        /// Üretimden sonraki tahmini saf/net metal ağırlığı (Gram).
        /// </summary>
        [Column(TypeName = "decimal(8,3)")]
        public decimal MetalWeightNet { get; set; }

        /// <summary>
        /// Üretimde beklenen metal fire/kayıp oranı (0.05 = %5).
        /// </summary>
        [Column(TypeName = "decimal(5,4)")]
        public decimal MetalLossRatio { get; set; } = 0.05M; // Varsayılan %5

        /// <summary>
        /// Reçetenin tipi (Üretim, Satış, vb. için bir Enum/FK'ya bağlanmalı).
        /// </summary>
        public byte BOMTypeId { get; set; }
        public required BOMType BOMType { get; set; } = null!;

        /// <summary>
        /// Bu reçeteye göre üretimin tamamlanması için tahmini toplam süre (saat cinsinden).
        /// </summary>
        public short TotalLeadTimeHours { get; set; } = 0;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        // --- İLİŞKİLER (REÇETE DETAYLARI) ---

        /// <summary>
        /// Bu reçetede kullanılan tüm taş bileşenleri.
        /// </summary>
        public ICollection<BOMStone> Stones { get; set; } = new List<BOMStone>();

        /// <summary>
        /// Bu reçeteye ait tüm işçilik ve diğer maliyetler.
        /// </summary>
        public ICollection<BOMLabor> Labors { get; set; } = new List<BOMLabor>();

        // Üretim Adımları (Routings) da buraya bağlanacaktır.
    }
}