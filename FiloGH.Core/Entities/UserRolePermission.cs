namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir UserRole'ün sahip olduğu yetkileri (Permission) tanımlayan ara tablodur.
    /// Kullanıcı Rollere, Roller İzinlere bağlanır.
    /// </summary>
    public class UserRolePermission
    {
        // Bileşik Anahtar (Composite Key: UserRoleId ve PermissionId)

        public byte UserRoleId { get; set; }
        public required UserRole UserRole { get; set; } = null!;

        public int PermissionId { get; set; }
        public required Permission Permission { get; set; } = null!;
    }
}