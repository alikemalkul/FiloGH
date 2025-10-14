using FiloGH.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir ürünün stoğa giren/çıkan, satılan veya üretilen somut varyasyonudur. 
    /// Her varyantın kendine ait bir Reçetesi (BOM) vardır.
    /// </summary>
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public required Product Product { get; set; } = null!;
        /// <summary>
        /// Ürüne basılan taranabilir fiziksel barkod.
        /// </summary>
        [MaxLength(100)]
        public string? Barcode { get; set; }
        /// <summary>
        /// Bu varyanta ait benzersiz SKU (Örn: 5001-14K-Sarı-12).
        /// Yapı: ProductVariant kaydedilirken, $"{Product.ProductCode}-{MetalPurity.Code}-{MetalColor.Code}-{Size}" şeklinde olabilir
        /// </summary>
        [MaxLength(100)]
        public required string SKU { get; set; }
        /// <summary>
        /// Üretici/Tedarikçi tarafından bu varyant için atanan kod (Bizim SKU'muzdan farklı).
        /// </summary>
        [MaxLength(100)]
        public string? SupplierCode { get; set; }
        /// <summary>
        /// Varyantı tanımlayan kullanıcı dostu açıklama (Örn: 14 Ayar Sarı Altın, Boy 12).
        /// </summary>
        [MaxLength(255)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // --- KUYUMCULUK ÖZELLİKLERİ ---

        /// <summary>
        /// Varyantın metal ayarı (Örn: 14K, 18K).
        /// </summary>
        public byte? MetalPurityId { get; set; }
        public MetalPurity? MetalPurity { get; set; } = null!;

        /// <summary>
        /// Ürünün Rengi (Örn: Sarı, Beyaz, Rose). Yeni MetalColor Entity'sine FK.
        /// </summary>
        public byte? MetalColorId { get; set; }
        public MetalColor? MetalColor { get; set; }

        /// <summary>
        /// Ürün bir yüzük ise yüzük ölçüsü (Örn: 12, 14.5).
        /// </summary>
        [Column(TypeName = "decimal(6,1)")]
        public decimal? Size { get; set; }
        [Column(TypeName = "decimal(6,1)")]
        public decimal? Length { get; set; }
        /// <summary>
        /// Bu varyantın taş ve diğerleri hariç standart metal net ağırlığı (Gram cinsinden).
        /// </summary>
        [Column(TypeName = "decimal(10,4)")] // Yüksek hassasiyet kritik
        public decimal StandardWeight { get; set; } = 0.0M;
        /// <summary>
        /// Bu varyantın standart üretim/alış maliyeti (Maliyet entity'sine FK olmalıdır, 
        /// ancak şimdilik basit tutmak için decimal).
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal StandardCost { get; set; } = 0.0M;
        /// <summary>
        /// Fiyatlandırma/Satış Tipi: Gram İşi mi (True) yoksa Tane İşi mi (False).
        /// </summary>
        public bool IsWeightBasedPricing { get; set; } = false; // False: Tane işi

        // --- ÜRETİM İLİŞKİSİ ---

        /// <summary>
        /// Bu varyantın üretimi için kullanılan standart reçete.
        /// </summary>
        public BillOfMaterials? BillOfMaterials { get; set; }

        // --- STOK/ENVANTER BİLGİLERİ ---

        /// <summary>
        /// Bu varyantın stok takibinde kullanılan birincil birimi (Adet).
        /// Genellikle "Adet" olacak.
        /// </summary>
        public byte StockUnitId { get; set; }
        public required UnitOfMeasure StockUnit { get; set; } = null!; // UnitOfMeasure Entity'si de tanımlanmalı.
    }
}