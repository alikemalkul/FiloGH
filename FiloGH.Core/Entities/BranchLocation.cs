namespace FiloGH.Core.Entities
{
    public class BranchLocation
    {
        // Composite Key (Birleşik Anahtar): BranchId ve LocationId
        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        public byte LocationId { get; set; }
        public required Location Location { get; set; } = null!;

        /// <summary>
        /// Bu erişim kaydının oluşturulma zamanı.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
