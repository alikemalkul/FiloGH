using FiloGH.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Sistemde bir kullanıcının gerçekleştirebileceği atomik aksiyonları tanımlar.
    /// </summary>
    public class Permission
    {
        public int Id { get; set; } // İzin sayısı fazla olabilir

        [MaxLength(100)]
        public required string Name { get; set; } // Örn: Sipariş Oluştur, Fiyat Gör

        /// <summary>
        /// Kod tabanında kullanılacak benzersiz izin kodu (Örn: INVENTORY_VIEW, ORDER_CREATE).
        /// </summary>
        [MaxLength(50)]
        public required string Code { get; set; }

        /// <summary>
        /// İznin ait olduğu ana modül (ModuleDefinition Enum'undan gelir).
        /// </summary>
        public UserModuleDefinition Module { get; set; }

        public bool IsActive { get; set; } = true;
    }
}