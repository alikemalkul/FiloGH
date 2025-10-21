using FiloGH.Application.DTOs.Product;
using FiloGH.Application.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiloGH.Application.Services // Namespace'i güncellendi
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ------------------------------------------------------------------
        // OKUMA İŞLEMLERİ
        // ------------------------------------------------------------------

        // Ürün Listesini (ProductListDto) Döndürür
        public async Task<IEnumerable<ProductListDto>> GetProductListAsync()
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();

            // Product Entity'sini Category ve Variants (StockUnit bilgisi için) ilişkileri ile çekme [10, 11]
            var products = await productRepository.GetAllAsync(
                filter: p => p.IsActive,
                include: source => source.Include(p => p.Category)
                                         .Include(p => p.Variants!)
            );

            return products.Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                ProductCategoryName = p.Category.Name, // ProductCategory Entity'den çekilir
                                                       // Stok miktarını varyantlardaki StandardWeight toplamından hesaplama
                TotalStockQuantity = p.Variants.Where(v => v.IsActive).Sum(v => v.StandardWeight),
                SKU = p.Variants.FirstOrDefault(v => v.IsActive)?.SKU ?? "N/A"
            }).ToList();
        }

        // Ürün Detayını (ProductGetDto) Döndürür
        public async Task<ProductGetDto?> GetProductDetailAsync(int productId)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();

            // Product Entity'si Category, Brand, CreatedBy ve MetalType bilgisi için Variants ilişkileri ile yüklenir.
            var productEntity = await productRepository.GetByIdAsync(
                productId,
                disableTracking: true,
                includeProperties: "Category,Brand,CreatedBy,Variants.MetalPurity.BaseMetal"
            );

            if (productEntity == null)
                return null;

            // Metal bilgisi ilk varyanttan çekilir (Metal bilgisi Product Entity'den kaldırıldığı için)
            var primaryVariant = productEntity.Variants.FirstOrDefault();
            var metalTypeId = primaryVariant?.MetalPurity?.BaseMetal?.Id;
            var metalTypeName = primaryVariant?.MetalPurity?.BaseMetal?.Name;

            // Burada DTO'ya manuel mapleme yapılır
            return new ProductGetDto
            {
                Id = productEntity.Id,
                Code = productEntity.ProductCode,
                Name = productEntity.Name,
                ProductCategoryId = productEntity.ProductCategoryId,
                ProductCategoryName = productEntity.Category.Name,

                // Metal Bilgileri (Varyanttan çekilen)
                MetalTypeId = metalTypeId ?? 0,
                MetalTypeName = metalTypeName ?? "N/A",

                // Fiyat/Ağırlık Bilgileri (Product Entity'sinde olduğu varsayılan, ancak kaynak kodunda detaylı listelenmemiş [9, 12, 13])
                // Bu alanlar Product entity'ye eklenmelidir, aksi takdirde 0 veya varsayılan değerler atanır.
                AverageWeight = 0,
                MinimumWeight = 0,
                MaximumWeight = 0,
                CostPrice = 0,
                SellingPrice = 0,

                IsActive = productEntity.IsActive,
                CanBeSold = true, // Entity'de açıkça yok, varsayılan atandı
                CanBeProduced = true, // Entity'de açıkça yok, varsayılan atandı

                // Denetim (Audit) Bilgileri (Product Entity'sinde eksik olduğu için geçici atama)
                CreatedAt = DateTimeOffset.Now,
                CreatedById = 1,
                CreatedByName = "System/Unknown",
                ModifiedAt = null,
            };
        }

        // ------------------------------------------------------------------
        // YENİ ÜRÜN OLUŞTURMA
        // ------------------------------------------------------------------

        public async Task<ProductGetDto> CreateProductAsync(ProductCreateDto productDto)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();

            // DTO'dan Entity'ye dönüşüm
            var productEntity = new Product
            {
                ProductCode = productDto.ProductCode,
                Name = productDto.Name,
                ProductCategoryId = productDto.ProductCategoryId, // int
                IsActive = productDto.IsActive,

                // Product Entity'ye ait diğer alanlar DTO'dan atanmalıdır.
                DesignCode = productDto.DesignCode,
                BrandId = productDto.BrandId,
                Category = null!,

                // Audit alanları:
                // CreatedAt = DateTimeOffset.UtcNow, 
                // CreatedById = 1, // Oturumdan alınmalı

                // Varyantların Entity'ye haritalanması
                Variants = productDto.Variants.Select(v => new ProductVariant
                {
                    SKU = v.SKU,
                    Name = v.Name,
                    StockUnitId = v.StockUnitId,
                    MetalPurityId = v.MetalPurityId,
                    MetalColorId = v.MetalColorId,
                    StandardWeight = v.StandardWeight,
                    StandardCost = v.StandardCost,
                    IsWeightBasedPricing = v.IsWeightBasedPricing,

                    // CS9035 Hata Çözümü: required navigasyon üyelerini null! olarak başlatma
                    Product = null!,
                    StockUnit = null!,
                    // MetalPurity ve MetalColor nullable olduğu için başlatmaya gerek yok
                }).ToList()
            };

            await productRepository.AddAsync(productEntity);
            await _unitOfWork.SaveAsync();

            // Kaydedilen Entity'yi (ProductGetDto'yu doldurmak için) ilişkileriyle yeniden çekme
            var createdProduct = await productRepository.GetByIdAsync(
                productEntity.Id,
                disableTracking: true,
                includeProperties: "Category,Brand,CreatedBy,Variants.MetalPurity.BaseMetal"
            );

            if (createdProduct == null)
            {
                throw new InvalidOperationException("Yeni oluşturulan ürün veritabanından alınamadı.");
            }

            // Metal ve Diğer DTO alanlarını haritalayarak dönme (Detaylı haritalama ProductGetDto tanımına uygundur)
            var primaryVariant = createdProduct.Variants.FirstOrDefault();

            return new ProductGetDto
            {
                Id = createdProduct.Id,
                Code = createdProduct.ProductCode,
                Name = createdProduct.Name,

                ProductCategoryId = createdProduct.ProductCategoryId,
                ProductCategoryName = createdProduct.Category.Name,

                MetalTypeId = primaryVariant?.MetalPurity?.BaseMetal?.Id ?? 0,
                MetalTypeName = primaryVariant?.MetalPurity?.BaseMetal?.Name ?? "N/A",

                AverageWeight = productDto.AverageWeight,
                MinimumWeight = productDto.MinimumWeight,
                MaximumWeight = productDto.MaximumWeight,
                CostPrice = productDto.CostPrice,
                SellingPrice = productDto.SellingPrice,

                IsActive = createdProduct.IsActive,
                CanBeSold = productDto.CanBeSold,
                CanBeProduced = productDto.CanBeProduced,

                // Denetim (Audit) Bilgileri (Entity'de eksik olduğu için geçici atama)
                CreatedAt = DateTimeOffset.Now,
                CreatedById = 1,
                CreatedByName = "System/Unknown",
                ModifiedAt = null,
            };
        }

        // ------------------------------------------------------------------
        // ÜRÜN GÜNCELLEME
        // ------------------------------------------------------------------

        public async Task UpdateProductAsync(ProductUpdateDto productDto)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();

            var existingProduct = await productRepository.GetByIdAsync(productDto.Id, disableTracking: false);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Ürün ID {productDto.Id} ile bulunamadı.");
            }

            // Temel Entity alanlarını güncelle
            existingProduct.Name = productDto.Name;
            existingProduct.ProductCategoryId = productDto.ProductCategoryId;
            existingProduct.IsActive = productDto.IsActive;
            // ... (Diğer alanlar güncellenir: BrandId, DesignCode, vb.)

            // Varyant koleksiyonundaki değişiklikler (ekleme/silme/güncelleme) burada ayrıca işlenmelidir.

            productRepository.Update(existingProduct);
            await _unitOfWork.SaveAsync();
        }

        // ------------------------------------------------------------------
        // PASİFLEŞTİRME VE VARYANT İŞLEMLERİ
        // ------------------------------------------------------------------

        public async Task<bool> DeactivateProductAsync(int productId)
        {
            var productRepository = _unitOfWork.GetRepository<Product, int>();
            // Varyantları da pasifleştirmek için yüklenir
            var existingProduct = await productRepository.GetByIdAsync(productId, disableTracking: false, includeProperties: "Variants");

            if (existingProduct == null) return false;

            existingProduct.IsActive = false;

            foreach (var variant in existingProduct.Variants)
            {
                variant.IsActive = false;
            }

            productRepository.Update(existingProduct);
            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeactivateVariantAsync(int variantId)
        {
            // ProductVariant artık IEntity<int> uyguladığı için GetRepository çağrısı geçerlidir.
            var variantRepository = _unitOfWork.GetRepository<ProductVariant, int>();
            var existingVariant = await variantRepository.GetByIdAsync(variantId, disableTracking: false);

            if (existingVariant == null) return false;

            existingVariant.IsActive = false;

            variantRepository.Update(existingVariant);
            return await _unitOfWork.SaveAsync() > 0;
        }

        // Varyant kaydetme metodu, ProductVariantCreateDto'dan ProductVariantGetDto döndürür.
        public Task<ProductVariantGetDto> SaveVariantAsync(ProductVariantCreateDto variantDto)
        {
            // Bu metot, DTO'dan Entity'ye (ProductVariant) haritalama, kaydetme ve geri dönüş DTO'su oluşturma mantığını içermelidir.
            throw new NotImplementedException("SaveVariantAsync metodu henüz tam olarak uygulanmamıştır.");
        }
    }

}
