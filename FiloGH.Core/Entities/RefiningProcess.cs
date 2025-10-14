using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Hurda ve saf metallerin karıştırılması/eritilmesi sonucu ayar ve ağırlık değişimini takip eden süreç.
    /// </summary>
    public class RefiningProcess
    {
        public long Id { get; set; }

        public DateTimeOffset ProcessDate { get; set; } = DateTimeOffset.Now;

        public byte MetalCurrencyId { get; set; }
        public required Currency MetalCurrency { get; set; } = null!;

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        // --- GİRİŞ BİLGİLERİ (INPUT) ---

        [Column(TypeName = "decimal(19,4)")]
        public decimal InputWeight { get; set; } // Rafinasyona giren toplam ağırlık

        public byte InputKaratId { get; set; }
        public required Karat InputKarat { get; set; } = null!; // Giren malzemenin ortalama ayarı

        // --- ÇIKIŞ BİLGİLERİ (OUTPUT) ---

        [Column(TypeName = "decimal(19,4)")]
        public decimal OutputWeight { get; set; } // İşlem sonrası elde edilen toplam ağırlık

        public byte OutputKaratId { get; set; }
        public required Karat OutputKarat { get; set; } = null!; // Yeni ayar

        // --- KAYIP/FARK ---

        /// <summary>
        /// Süreçteki fiili metal kaybı (InputWeight - OutputWeight).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal LossWeight { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}