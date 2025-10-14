using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir siparişe (Order) uygulanan ek ücretlerin (Kargo, Komisyon, Özel İşçilik vb.) detay satırları.
    /// </summary>
    public class OrderAdditionalFee
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public required Order Order { get; set; } = null!;

        public byte AdditionalFeeDefinitionId { get; set; }
        public required OrderAdditionalFeeDefinition AdditionalFeeDefinition { get; set; } = null!; // Yeni/Eksik Entity

        /// <summary>
        /// Used when AdditionalFeeDefinition command type equals 'OTHER', otherwise null
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }

        // --- MİKTAR VE HESAPLAMA ---

        /// <summary>
        /// Ücretin tutarı veya yüzdesi. AmountType alanına göre yorumlanır.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] // Hassasiyeti 4'e yükselttim.
        public decimal Amount { get; set; }

        /// <summary>
        /// Ücretin hesaplanma şekli: 1=Amount (Sabit Tutar), 2=Percentage (Yüzde).
        /// </summary>
        public byte AmountTypeId { get; set; }
        public required OrderFeeAmountType AmountType { get; set; } = null!; // Yeni/Eksik Entity

        /// <summary>
        /// Vergi Oranı. (0.18, 0.20 vb.)
        /// </summary>
        [Column(TypeName = "decimal(5,4)")] // Hassasiyet ve aralığı 5,4 olarak güncelledim (0.0001'den %100'e kadar)
        public decimal TaxRate { get; set; }

        public bool IsTaxIncluded { get; set; } = false; // EKLEME: KDV/Vergi fiyata dahil mi?

        // --- MUHASEBE ENTEGRASYONU ---

        /// <summary>
        /// Bu ücretin muhasebede işleneceği Hesap Planı ID'si (Örn: 602 Diğer Gelirler).
        /// </summary>
        public int AccountingAccountId { get; set; } // EKLEME
        public required AccountChart AccountingAccount { get; set; } = null!; // Eksik Entity
    }
}