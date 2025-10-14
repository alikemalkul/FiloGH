using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Belirli bir stok kaleminin (StockItem) belirli bir lokasyondaki anlık miktarını ve maliyetini tutar.
    /// Kuyumculuğa özel metal ve karat ağırlığını içerir.
    /// </summary>
    public class InventoryLevel
    {
        public int Id { get; set; }

        // --- BOYUTLAR (Dimension) ---

        public int StockItemId { get; set; }
        public required StockItem StockItem { get; set; } = null!;

        public byte LocationId { get; set; }
        public required Location Location { get; set; } = null!; // ✅ Location FK

        /// <summary>
        /// Sadece saf metal stokları (Hammadde) için kullanılır. Hangi ayar (14K, 18K) olduğunu belirtir.
        /// </summary>
        public byte? MetalPurityId { get; set; }
        public MetalPurity? MetalPurity { get; set; } // ✅ MetalPurity FK

        // --- MİKTARLAR (Quantities) ---

        [Column(TypeName = "decimal(19,4)")]
        public decimal Quantity { get; set; } = 0.0M;

        /// <summary>
        /// İlgili kalemdeki toplam brüt metal ağırlığı (Gram/Ons).
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalMetalWeightGross { get; set; } = 0.0M;

        /// <summary>
        /// İlgili kalemdeki toplam net/has metal ağırlığı (Gram/Ons). (Kuyumculuk için kritik)
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal TotalMetalWeightNet { get; set; } = 0.0M;

        /// <summary>
        /// İlgili kalemdeki toplam taş Karat ağırlığı (ct).
        /// </summary>
        [Column(TypeName = "decimal(10,4)")]
        public decimal TotalCaratWeight { get; set; } = 0.0M;

        // --- MALİYET VE ZAMAN ---

        /// <summary>
        /// Stok maliyet değeri (Moving Average Cost - MAC). (BaseCurrency cinsinden)
        /// </summary>
        [Column(TypeName = "decimal(19,4)")]
        public decimal ValuationCost { get; set; } = 0.0M;
    }
}