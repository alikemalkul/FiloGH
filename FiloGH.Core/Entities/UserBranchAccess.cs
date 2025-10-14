namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Kullanıcının (User) hangi şubelere (Branch) erişim yetkisinin olduğunu tanımlayan ara tablodur.
    /// Bileşik Anahtar: UserId ve BranchId
    /// </summary>
    public class UserBranchAccess
    {
        public byte UserId { get; set; }
        public required User User { get; set; } = null!;

        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        /// <summary>
        /// Kullanıcının bu şubede veri oluşturma, düzenleme ve silme yetkisine sahip olup olmadığı.
        /// (Okuma yetkisi genellikle UserRolePermission ile belirlenir.)
        /// </summary>
        public bool CanWrite { get; set; } = true;
    }
}