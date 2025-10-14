using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Stok Kaleminin türünü (Mamul, Yarı Mamul, Hammadde, Taş, Ambalaj vb.) tanımlar.
    /// </summary>
    public class StockItemType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        /// <summary>
        /// Mamul, Hammadde, Taş, Hizmet
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// FNSH, RAW, STN, SVC gibi kısa kod.
        /// </summary>
        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Bu türdeki bir kalemin fiziksel stok takibine tabi olup olmadığı. (Hizmetler için False)
        /// </summary>
        public bool IsTracked { get; set; } = true;

        public bool IsActive { get; set; } = true;
    }
}