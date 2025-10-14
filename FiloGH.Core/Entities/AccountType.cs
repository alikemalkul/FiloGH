using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Muhasebe hesaplarının temel tiplerini (Varlık, Borç, Gelir, Gider) tanımlar.
    /// </summary>
    public class AccountType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Hesabın Bilanço (1) mı yoksa Gelir Tablosu (2) mu ile ilişkili olduğunu belirtir.
        /// </summary>
        public byte FinancialStatementCategory { get; set; }

        public bool IsActive { get; set; } = true;

        // public ICollection<AccountChart> Accounts { get; set; }
    }
}