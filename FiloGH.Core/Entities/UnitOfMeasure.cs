using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class UnitOfMeasure : IEntity<byte>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Birimin türü (Ağırlık, Adet, Uzunluk vb.).
        /// </summary>
        public byte UomTypeId { get; set; }
        public required UomType UomType { get; set; } = null!; // UomType Entity'sine FK

        // --- ÇEVRİM BİLGİLERİ (Conversion) ---

        /// <summary>
        /// Bu UOM'un çevrim yaptığı ana UOM ID'si. Null ise kendisi ana birimdir.
        /// </summary>
        public byte? BaseUnitId { get; set; }
        public UnitOfMeasure? BaseUnit { get; set; }

        /// <summary>
        /// Bu birimden BaseUnit'e çevrim faktörü. Örn: Ons için 31.1035.
        /// </summary>
        [Column(TypeName = "decimal(10,5)")] // Yüksek hassasiyet kritik
        public decimal ConversionFactor { get; set; } = 1.0M;
        /// <summary>
        /// Birimdeki ondalık hassasiyet (Örn: Gram için 3-4, Adet için 0). StockUnitOfMeasure'dan taşındı.
        /// </summary>
        public byte DecimalPlaces { get; set; } = 2; 
        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER (Kendine referans) ---

        public ICollection<UnitOfMeasure> RelatedUnits { get; set; } = new List<UnitOfMeasure>();

        // ... (Product, MetalType gibi Entity'lere olan ters ilişkiler)
    }
}