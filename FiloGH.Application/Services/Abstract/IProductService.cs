using FiloGH.Application.DTOs;

namespace FiloGH.Application.Interfaces
{
    /// <summary>
    /// Ürün ve Ürün Varyantı yönetimi için iş mantığı arayüzü.
    /// </summary>
    public interface IProductService
    {
        // Tüm ürünleri liste DTO formatında çeker (Sadece temel bilgiler)
        Task<IEnumerable<ProductListDto>> GetProductListAsync();

        // Belirli bir ID'ye sahip ürünü, varyantlarıyla birlikte detay DTO olarak çeker
        Task<ProductDetailDto?> GetProductDetailAsync(int productId);

        // Yeni ürün oluşturur veya mevcut ürünü günceller (Upsert)
        Task<ProductDetailDto> SaveProductAsync(ProductDetailDto productDto);

        // Bir ürünü ve tüm varyantlarını pasif hale getirir (Soft Delete)
        Task<bool> DeactivateProductAsync(int productId);

        // --- Varyant Yönetimi ---

        // Mevcut bir ürüne yeni bir varyant ekler veya günceller
        Task<ProductVariantDto> SaveVariantAsync(ProductVariantDto variantDto);

        // Belirli bir varyantı pasif hale getirir (Soft Delete)
        Task<bool> DeactivateVariantAsync(int variantId);
    }
}
