// FiloGH.Core/Entities/Branch.cs (Nihai ve Güncel Yapı)

using FiloGH.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class Branch : IEntity<byte>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; }

        [MaxLength(255)]
        public required string Name { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// Bu şubenin perakende veya toptan satış işlemlerini gerçekleştiren bir satış noktası olup olmadığı.
        /// </summary>
        public bool IsSalesPoint { get; set; } = false; // ✅ Yeni Eklendi

        // --- ŞİRKET İLİŞKİSİ ---
        public byte OwnCompanyId { get; set; }
        public required OwnCompany OwnCompany { get; set; } = null!;

        // --- ADRES VE İLETİŞİM ---
        public int? AddressId { get; set; }
        public MailingAddress? Address { get; set; }

        // --- VARSAYILAN LOKASYONLAR (OPERASYONEL) ---
        public byte DefaultCashLocationId { get; set; }
        public required Location DefaultCashLocation { get; set; } = null!;

        public byte DefaultMetalLocationId { get; set; }
        public required Location DefaultMetalLocation { get; set; } = null!;

        // --- KOLEKSİYONLAR ---
        public ICollection<BranchLocation> BranchLocations { get; set; } = new List<BranchLocation>();
    }
}