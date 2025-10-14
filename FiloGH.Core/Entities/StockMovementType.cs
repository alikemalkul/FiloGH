// FiloGH.Core/Entities/StockMovementType.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Stok hareketlerinin türünü (Satış, Alış, Üretim Girişi, Fire vb.) tanımlar.
    /// </summary>
    public class StockMovementType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Stok miktarındaki değişimin işaretini tutar. 
        /// +1: Giriş (Stoğu artırır) 
        /// -1: Çıkış (Stoğu azaltır)
        /// 0: Transfer/Muhasebe (Miktarı değiştirmez, sadece değeri ayarlar)
        /// </summary>
        public short Sign { get; set; }

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        // public ICollection<StockTransaction> Transactions { get; set; } // Bu tipe ait hareketler
    }
}