namespace FiloGH.Models.Entities
{
    public class ProductOption
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
        public byte Position { get; set; }
        public int ProductOptionDefinitionId { get; set; }
        public required ProductOptionDefinition ProductOptionDefinition { get; set; }
    }
}
