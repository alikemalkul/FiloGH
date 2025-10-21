using FiloGH.Application.DTOs;
using FiloGH.Application.DTOs.Product;

namespace FiloGH.Application.Interfaces
{
    /// <summary>
    /// Ürün ve Ürün Varyantı yönetimi için iş mantığı arayüzü.
    /// </summary>
    public interface IProductService
    {
        // CRUD ve Listeleme Metotları (Product Entity'si için)

        // Ürünlerin temel listesini döndürür (Stok özeti dahil).
        Task<IEnumerable<ProductListDto>> GetProductListAsync();

        // Belirli bir ürünün detaylarını döndürür.
        Task<ProductGetDto?> GetProductDetailAsync(int productId);

        // Yeni bir ürün oluşturur ve oluşturulan ürünün detay DTO'sunu döndürür.
        Task<ProductGetDto> CreateProductAsync(ProductCreateDto productDto);

        // Mevcut bir ürünü günceller.
        Task UpdateProductAsync(ProductUpdateDto productDto);

        // Ürünü ve tüm varyantlarını pasifleştirir (mantıksal silme).
        Task<bool> DeactivateProductAsync(int productId);

        // Varyant İşlemleri

        // Yeni bir varyantı kaydeder veya mevcut bir varyantı günceller 
        // ve oluşturulan/güncellenen varyantın detay DTO'sunu döndürür.
        Task<ProductVariantGetDto> SaveVariantAsync(ProductVariantCreateDto variantDto);

        // Belirli bir varyantı pasifleştirir.
        Task<bool> DeactivateVariantAsync(int variantId);

        // Not: Eğer bir GetVariantDetail metodu eklenirse, buraya da eklenmelidir:
        // Task<ProductVariantGetDto?> GetProductVariantDetailAsync(int variantId);
    }
}
