// FiloGH.Core/Entities/StockTransaction.cs (Gelişmiş Metal Stok Takibi - Nihai)
using FiloGH.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class StockTransaction : IEntity<long>
    {
        public long Id { get; set; }

        // --- HAREKET TÜRÜ ---
        public byte MovementTypeId { get; set; }
        public required StockMovementType MovementType { get; set; } = null!; 

        public DateTimeOffset TransactionDate { get; set; }

        // --- HAREKETİN KAYNAĞI ---
        public int? SourceOrderLineId { get; set; }
        public OrderLine? SourceOrderLine { get; set; }

        [MaxLength(50)]
        public string? ReferenceDocType { get; set; } 

        // --- LOKASYON BİLGİLERİ ---

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        // NOT: Buradaki Location muhtemelen genel Location entitesi değil,
        // daha önce oluşturduğumuz StockLocation entitesine karşılık gelmeli.
        // Ancak siz 'Location' ismini kullandığınız için şimdilik öyle bırakıyorum.
        // Projenin geri kalanında tutarlılık için 'StockLocation' adını kullanmaya özen gösterelim.
        public byte LocationId { get; set; }
        public required Location Location { get; set; } = null!; 

        // --- EN TEMEL METAL BİLGİLERİ ---

        public byte MetalCurrencyId { get; set; }
        public required Currency MetalCurrency { get; set; } = null!;

        public byte? MetalPurityId { get; set; }
        public MetalPurity? MetalPurity { get; set; } 

        [Column(TypeName = "decimal(19,4)")]
        public decimal Fineness { get; set; } 

        [Column(TypeName = "decimal(19,4)")]
        public decimal WeightInGrams { get; set; } // Ticari ağırlık

        // --- SABİTLENMİŞ MALİYET BİLGİLERİ ---

        public byte BaseExchangeCurrencyId { get; set; }
        public required Currency BaseExchangeCurrency { get; set; } = null!; 

        [Column(TypeName = "decimal(19,4)")]
        public decimal CostPerGramEUR { get; set; } 

        [Column(TypeName = "decimal(19,8)")]
        public decimal FixedExchangeRate { get; set; } 

        // --- KULLANICI / TAKİP ---
        public byte CreatedById { get; set; }
        public required User CreatedBy { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; } 
    }
}