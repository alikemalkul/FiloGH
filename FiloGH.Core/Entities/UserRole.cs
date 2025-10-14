using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Kullanıcının sistemdeki görevini tanımlayan temel yetkilendirme rolü.
    /// </summary>
    public class UserRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: ERP Admin, Satış Temsilcisi

        [MaxLength(20)]
        public required string Code { get; set; } // Örn: ADMIN, SALES_REP

        /// <summary>
        /// Yeni kullanıcılara varsayılan olarak atanacak rol olup olmadığı.
        /// </summary>
        public bool IsDefault { get; set; } = false;

        public bool IsActive { get; set; } = true;

        // --- İLİŞKİLER ---

        // public ICollection<User> Users { get; set; } // Bu role sahip kullanıcılar (Opsiyonel)
        // public ICollection<UserRolePermission> Permissions { get; set; } // Bu role ait detaylı izinler
    }
}