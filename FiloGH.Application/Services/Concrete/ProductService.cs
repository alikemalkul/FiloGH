using FiloGH.Application.DTOs;
using FiloGH.Application.Interfaces;

namespace FiloGH.Application.Services.Concrete // Namespace'i güncellendi
{
    // Mock Servis, Gerçek DB entegrasyonu gelene kadar bellekte veri tutar
    public class ProductService : IProductService
    {
        private static int _nextProductId = 4; // Başlangıç ID'si 1'den başlar
        private static int _nextVariantId = 104; // Varyant ID'leri

        // Product Detail Data Store
        private static readonly List<ProductDetailDto> _products = new List<ProductDetailDto>
        {
            new ProductDetailDto
            {
                Id = 1,
                Name = "Pırlanta Tektaş Yüzük",
                CategoryName = "Yüzük",
                IsActive = true,
                Variants = new List<ProductVariantDto>
                {
                    new ProductVariantDto { Id = 101, ProductId = 1, SKU = "PRL-001-B", Size = "Beyaz Altın", Color = "0.50 ct", StockQuantity = 5, IsActive = true },
                    new ProductVariantDto { Id = 102, ProductId = 1, SKU = "PRL-001-R", Size = "Rose Gold", Color = "0.50 ct", StockQuantity = 10, IsActive = true }
                }
            },
            new ProductDetailDto
            {
                Id = 2,
                Name = "Altın Halka Küpe",
                CategoryName = "Küpe",
                IsActive = true,
                Variants = new List<ProductVariantDto>
                {
                    new ProductVariantDto { Id = 103, ProductId = 2, SKU = "ALT-202-K", Size = "Krem", Color = "Sarı Altın", StockQuantity = 45, IsActive = true }
                }
            },
            new ProductDetailDto
            {
                Id = 3,
                Name = "Gümüş Zincir Kolye",
                CategoryName = "Kolye",
                IsActive = false, // Pasif Ürün
                Variants = new List<ProductVariantDto>() // Varyantları yok
            }
        };

        // Tüm aktif ürünleri liste DTO formatında çeker
        public Task<IEnumerable<ProductListDto>> GetProductListAsync()
        {
            var list = _products
                .Where(p => p.IsActive)
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryName = p.CategoryName,
                    // Aktif varyantların toplam stoğunu hesapla
                    TotalStockQuantity = p.Variants.Where(v => v.IsActive).Sum(v => v.StockQuantity),
                    // Eğer aktif varyant varsa ilk varyantın SKU'sunu, yoksa boş döndür.
                    SKU = p.Variants.FirstOrDefault(v => v.IsActive)?.SKU ?? "N/A"
                })
                .OrderByDescending(p => p.Name)
                .ToList();

            return Task.FromResult<IEnumerable<ProductListDto>>(list);
        }

        // Belirli bir ID'ye sahip ürünü detay DTO olarak çeker
        public Task<ProductDetailDto?> GetProductDetailAsync(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            return Task.FromResult(product);
        }

        // Yeni ürün oluşturur veya mevcut ürünü günceller (Upsert)
        public Task<ProductDetailDto> SaveProductAsync(ProductDetailDto productDto)
        {
            if (productDto.Id == 0) // Yeni Ürün
            {
                productDto.Id = _nextProductId++;
                productDto.IsActive = true;
                _products.Add(productDto);
            }
            else // Güncelleme
            {
                var existingProduct = _products.FirstOrDefault(p => p.Id == productDto.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = productDto.Name;
                    existingProduct.CategoryName = productDto.CategoryName;
                    existingProduct.IsActive = productDto.IsActive;
                    // Not: Bu mock serviste varyant listesi ProductDetailDto ile birlikte güncellenmez.
                    // Varyantlar, SaveVariantAsync metodu ile ayrı ayrı yönetilmelidir.
                }
                else
                {
                    throw new KeyNotFoundException($"Ürün ID {productDto.Id} ile bulunamadı.");
                }
            }
            return Task.FromResult(productDto);
        }

        // Bir ürünü ve tüm varyantlarını pasif hale getirir (Soft Delete)
        public Task<bool> DeactivateProductAsync(int productId)
        {
            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.IsActive = false;
                // Ürünün tüm varyantlarını da pasifleştir
                product.Variants.ForEach(v => v.IsActive = false);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        // Mevcut bir ürüne yeni bir varyant ekler veya günceller
        public Task<ProductVariantDto> SaveVariantAsync(ProductVariantDto variantDto)
        {
            var product = _products.FirstOrDefault(p => p.Id == variantDto.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Varyantın ekleneceği Ürün ID {variantDto.ProductId} bulunamadı.");
            }

            if (variantDto.Id == 0) // Yeni Varyant
            {
                variantDto.Id = _nextVariantId++;
                variantDto.IsActive = true;
                product.Variants.Add(variantDto);
            }
            else // Güncelleme
            {
                var existingVariant = product.Variants.FirstOrDefault(v => v.Id == variantDto.Id);
                if (existingVariant != null)
                {
                    existingVariant.SKU = variantDto.SKU;
                    existingVariant.Size = variantDto.Size;
                    existingVariant.Color = variantDto.Color;
                    existingVariant.StockQuantity = variantDto.StockQuantity;
                    existingVariant.IsActive = variantDto.IsActive;
                }
                else
                {
                    throw new KeyNotFoundException($"Varyant ID {variantDto.Id} ile bulunamadı.");
                }
            }
            return Task.FromResult(variantDto);
        }

        // Belirli bir varyantı pasif hale getirir (Soft Delete)
        public Task<bool> DeactivateVariantAsync(int variantId)
        {
            foreach (var product in _products)
            {
                var variant = product.Variants.FirstOrDefault(v => v.Id == variantId);
                if (variant != null)
                {
                    variant.IsActive = false;
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
