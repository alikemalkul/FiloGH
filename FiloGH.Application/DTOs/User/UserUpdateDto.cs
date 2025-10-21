using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.User
{
    /// <summary>
    /// Mevcut bir Kullanıcının temel ve ilişki bilgilerini güncellemek için kullanılan DTO.
    /// </summary>
    public record UserUpdateDto
    {
        // Entity'niz ile eşleşmesi için tip byte olarak ayarlandı
        [Required(ErrorMessage = "Kullanıcı Kimliği zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Kullanıcı Kimliği belirtilmelidir.")]
        public required byte Id { get; init; }

        [Required(ErrorMessage = "Kullanıcı Adı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.")]
        public required string Username { get; init; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad en fazla 100 karakter olmalıdır.")]
        public required string FirstName { get; init; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [MaxLength(100, ErrorMessage = "Soyad en fazla 100 karakter olmalıdır.")]
        public required string LastName { get; init; }

        [EmailAddress(ErrorMessage = "Geçerli bir E-posta adresi giriniz.")]
        [MaxLength(255, ErrorMessage = "E-posta adresi en fazla 255 karakter olmalıdır.")]
        public string? Email { get; init; }

        /// <summary>
        /// Kullanıcının aktiflik durumu.
        /// </summary>
        public required bool IsActive { get; init; }

        // --- İLİŞKİLİ ALANLAR (byte tipinde) ---

        [Required(ErrorMessage = "Birincil Şube (Branch) zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Şube Kimliği belirtilmelidir.")]
        public required byte PrimaryBranchId { get; init; }

        [Required(ErrorMessage = "Kullanıcı Rolü zorunludur.")]
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Rol Kimliği belirtilmelidir.")]
        public required byte UserRoleId { get; init; }

        /// <summary>
        /// Varsayılan Para Birimi Kimliği (Opsiyonel)
        /// </summary>
        [Range(1, byte.MaxValue, ErrorMessage = "Geçerli bir Para Birimi Kimliği belirtilmelidir.")]
        public byte? DefaultCurrencyId { get; init; }
    }
}
