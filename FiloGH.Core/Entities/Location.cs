using FiloGH.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public byte Position { get; set; }
        public bool IsActive { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        /// <summary>
        /// Lokasyonun tipini belirler (Enum olarak saklanır).
        /// </summary>
        public LocationType Type { get; set; }

        public ICollection<BranchLocation> BranchLocations { get; set; } = new List<BranchLocation>();


        // --- İLİŞKİLER ---

        // Bu lokasyonda bulunan stok miktarları (InventoryLevel Entity'si ile ilişkilendirilebilir)
        // public ICollection<InventoryLevel> InventoryLevels { get; set; }
    }
}
