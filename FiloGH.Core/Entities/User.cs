using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } 
        
        // --- KULLANICI ADI VE TEMEL BİLGİLER ---
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.")]
        public required string Username { get; set; }

        [MaxLength(255)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Geçerli bir e-posta adresi giriniz.")] 
        public string? Email { get; set; } // Opsiyonel

        [MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public required string LastName { get; set; }

        //Password hash lemeden önce böyleydi
        //[Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        //[StringLength(100, MinimumLength = 8, ErrorMessage = "Şifre en az 8 karakter uzunluğunda olmalıdır.")]
        //[DataType(DataType.Password)] // UI kontrollerine (örneğin Blazor'da InputText) ipucu verir
        //                              // Regex ile karmaşıklık kuralları
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Şifre en az bir küçük harf, bir büyük harf ve bir rakam içermeli ve en az 8 karakter olmalıdır.")]
        //[MaxLength(50)]
        //public required string Password { get; set; }

        [MaxLength(255)]
        public required string PasswordHash { get; set; }
        
        public bool IsActive { get; set; } = true;

        // --- KİŞİSELLEŞTİRME VE İLİŞKİLER ---
        
        public byte? DefaultCurrencyId { get; set; }
        public Currency? DefaultCurrency { get; set; }

        public byte PrimaryBranchId { get; set; } 
        public required Branch PrimaryBranch { get; set; } = null!;

        public byte UserRoleId { get; set; } 
        public required UserRole UserRole { get; set; } = null!;

        // --- TAKİP (AUDIT) ---
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? LastLogin { get; set; }

        public ICollection<UserBranchAccess> BranchAccesses { get; set; } = new List<UserBranchAccess>();
    }
}