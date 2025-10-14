using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Muhasebe kayıtlarının yapıldığı hiyerarşik hesap planını (General Ledger - GL) tanımlar.
    /// </summary>
    public class AccountChart
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: 102.01.001

        [MaxLength(150)]
        public required string Name { get; set; }

        public int? ParentAccountId { get; set; }
        public AccountChart? ParentAccount { get; set; }

        public byte AccountTypeId { get; set; }
        public required AccountType AccountType { get; set; } = null!; // Eksik Entity

        /// <summary>
        /// Bu hesaba doğrudan muhasebe fişi (JournalEntry) atılabilir mi? (False ise grup hesabıdır).
        /// </summary>
        public bool IsPostingAccount { get; set; } = true;

        /// <summary>
        /// Bu hesap metal (altın/gümüş/platium) bakiyesi tutmak için mi kullanılıyor? (Kuyumculuk ERP'si için kritik).
        /// </summary>
        public bool IsMetalAccount { get; set; } = false; // EKLEME

        public bool IsActive { get; set; } = true;

        public ICollection<AccountChart> ChildAccounts { get; set; } = new List<AccountChart>();
        // ...
    }
}