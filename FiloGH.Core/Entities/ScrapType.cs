using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Hurda hareketlerinin (ScrapTransaction) kaynağını ve tipini tanımlar (Fire, Kazanç, Rafinasyon, vb.).
    /// </summary>
    public class ScrapType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<ScrapTransaction> Transactions { get; set; }
    }
}