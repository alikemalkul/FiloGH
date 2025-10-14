namespace FiloGH.Models.Entities
{
    public class TimeLine
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public required User CreatedBy { get; set; }
        public int OrderId { get; set; }
        public required Order Order { get; set; }
        public string? Comment { get; set; }
    }
}
