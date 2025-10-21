namespace FiloGH.Application.DTOs.Product
{
    public record ProductListDto
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string ProductCategoryName { get; init; }
        // Listeleme amacıyla kullanılan bu alan, Servis tarafından hesaplanmıştır.
        public required decimal TotalStockQuantity { get; init; }
        public required string SKU { get; init; }
    }
}
