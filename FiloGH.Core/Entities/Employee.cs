using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Şirket çalışanı veya yetkili kullanıcısını tanımlar. User/Identity sistemi ile birebir eşleşir.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; } // Uygulama User/Identity Id'si ile aynı olmalıdır.

        [MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public required string LastName { get; set; }

        /// <summary>
        /// Personel Numarası/Sicil Kodu.
        /// </summary>
        [MaxLength(20)]
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Çalışanın bağlı olduğu ana şube (Birden fazla lokasyonda çalışabilir).
        /// </summary>
        public byte PrimaryBranchId { get; set; }
        public required Branch PrimaryBranch { get; set; } = null!;

        /// <summary>
        /// Çalışanın Departmanı. (Opsiyonel olarak ayrı bir Department Entity'sine FK verilebilir).
        /// </summary>
        [MaxLength(100)]
        public string? Department { get; set; }

        /// <summary>
        /// Çalışanın pozisyonu.
        /// </summary>
        [MaxLength(100)]
        public string? JobTitle { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset HireDate { get; set; }

        // --- İletişim Bilgileri (Temel) ---
        [MaxLength(255)]
        public string? Email { get; set; }
    }
}