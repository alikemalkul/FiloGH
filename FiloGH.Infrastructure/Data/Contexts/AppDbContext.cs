using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq; // LINQ kullanımı için eklendi

namespace FiloGH.Infrastructure.Data.Contexts
{
    /// <summary>
    /// EF Core için ana Veritabanı Bağlamı. Tüm entiteleri DbSet olarak içerir
    /// ve ilişkisel kuralları (Foreign Key, DeleteBehavior) konfigüre eder.
    /// Konum: FiloGH.Infrastructure/Data/Contexts
    /// </summary>
    //Add Migration: dotnet ef migrations add FixUomRelationships -p FiloGH.Infrastructure -s FiloGH
    //Delete Migration: 
    //Update Database: dotnet ef database update -p FiloGH.Infrastructure -s FiloGH
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ====================================================================
        // TÜM ENTTİTELERİN DbSet TANIMLARI
        // ====================================================================

        // Muhasebe ve Finans
        public DbSet<AccountChart> AccountCharts { get; set; }
        public DbSet<AccountingJournalEntry> AccountingJournalEntries { get; set; }
        public DbSet<AccountingJournalEntryLine> AccountingJournalEntryLines { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cash> CashRegisters { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }

        // Müşteri, Partner ve Organizasyon
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OwnCompany> OwnCompanies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchLocation> BranchLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MailingAddress> MailingAddresses { get; set; }

        // Sipariş ve Fatura
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<OrderFulfillment> OrderFulfillments { get; set; }
        public DbSet<OrderMetalSummary> OrderMetalSummaries { get; set; }
        public DbSet<OrderAdditionalFee> OrderAdditionalFees { get; set; }
        public DbSet<OrderAdditionalFeeDefinition> OrderAdditionalFeeDefinitions { get; set; }
        public DbSet<OrderFeeAmountType> OrderFeeAmountTypes { get; set; }
        public DbSet<OrderTaxLine> OrderTaxLines { get; set; }
        public DbSet<OrderPaymentLine> OrderPaymentLines { get; set; }
        public DbSet<OrderPaymentStatus> OrderPaymentStatuses { get; set; }
        public DbSet<OrderStatusDefinition> OrderStatusDefinitions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<RootType> RootTypes { get; set; } // Satış/Alış/İade Fatura tipi

        // Ürün, Stok ve Envanter
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockItemType> StockItemTypes { get; set; }
        public DbSet<InventoryLevel> InventoryLevels { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<InventoryTransactionType> InventoryTransactionTypes { get; set; }
        public DbSet<InventoryCost> InventoryCosts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<StockMovementType> StockMovementTypes { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<RawMaterialType> RawMaterialTypes { get; set; }
        public DbSet<OrderLineCost> OrderLineCost { get; set; } // Ekstra DbSet, ilişki tanımında geçtiği için eklendi.

        // Üretim ve Reçete (BOM)
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<ProductionOrderStatus> ProductionOrderStatuses { get; set; }
        public DbSet<ProductionRouting> ProductionRoutings { get; set; }
        public DbSet<ProductionRoutingItem> ProductionRoutingItems { get; set; }
        public DbSet<ProductionRoutingStep> ProductionRoutingSteps { get; set; }
        public DbSet<ProductionTransaction> ProductionTransactions { get; set; }
        public DbSet<ProductionTransactionType> ProductionTransactionTypes { get; set; }
        public DbSet<ProductionWorkCenter> ProductionWorkCenters { get; set; }
        public DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        public DbSet<BOMCostType> BOMCostTypes { get; set; }
        public DbSet<BOMLabor> BOMLabors { get; set; }
        public DbSet<BOMStone> BOMStones { get; set; }
        public DbSet<BOMStoneType> BOMStoneTypes { get; set; }
        public DbSet<BOMType> BOMTypes { get; set; }
        public DbSet<RoutingPurpose> RoutingPurposes { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<WorkOrderOperation> WorkOrderOperations { get; set; }
        public DbSet<OperationDefinition> OperationDefinitions { get; set; }
        public DbSet<OperationStatus> OperationStatuses { get; set; }
        public DbSet<WorkCenter> WorkCenters { get; set; }
        public DbSet<WorkCenterOperation> WorkCenterOperations { get; set; }
        public DbSet<WorkOrderOperationLog> WorkOrderOperationLogs { get; set; }


        // Metal ve Kuyumculuk Spesifik
        public DbSet<MetalType> MetalTypes { get; set; }
        public DbSet<MetalPurity> MetalPurities { get; set; }
        public DbSet<MetalColor> MetalColor { get; set; }
        public DbSet<DailyMetalRate> DailyMetalRates { get; set; }
        public DbSet<CustomerMetalAccount> CustomerMetalAccounts { get; set; }
        public DbSet<CustomerMetalAccountTransaction> CustomerMetalAccountTransactions { get; set; }
        public DbSet<CustomerMetalAccountTransactionType> CustomerMetalAccountTransactionTypes { get; set; }
        public DbSet<RefiningProcess> RefiningProcesses { get; set; }
        public DbSet<ScrapTransaction> ScrapTransactions { get; set; }
        public DbSet<ScrapType> ScrapTypes { get; set; }
        public DbSet<Karat> Karats { get; set; }

        // Ölçü Birimleri (UoM) ve Fiyatlandırma
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<UnitOfMeasureConversion> UnitOfMeasureConversions { get; set; }
        public DbSet<UomType> UomTypes { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<SalePricingRule> SalePricingRules { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        // Kullanıcılar ve Yetkilendirme (Security/Audit)
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserBranchAccess> UserBranchAccesses { get; set; }
        public DbSet<UserRolePermission> UserRolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }


        // ====================================================================
        // MODEL İLİŞKİLERİNİ VE KURALLARINI TANIMLAMA (OnModelCreating)
        // ====================================================================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------------------------------------------
            // B. M:M İLİŞKİLER (BİRLEŞİK ANAHTARLAR)
            // -----------------------------------------------------------

            // F. BranchLocation (Çözüldü: BranchId ve LocationId birleşik anahtardır)
            modelBuilder.Entity<BranchLocation>()
                .HasKey(bl => new { bl.BranchId, bl.LocationId });
            modelBuilder.Entity<BranchLocation>()
                .HasOne(bl => bl.Branch)
                .WithMany(l => l.BranchLocations)
                .HasForeignKey(bl => bl.BranchId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BranchLocation>()
                .HasOne(bl => bl.Location)
                .WithMany()
                .HasForeignKey(bl => bl.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // G. ProductionRoutingItem (Çözüldü: ProductVariantId ve ProductionRoutingId birleşik anahtardır)
            modelBuilder.Entity<ProductionRoutingItem>()
                .HasKey(pri => new { pri.ProductVariantId, pri.ProductionRoutingId });
            modelBuilder.Entity<ProductionRoutingItem>()
                .HasOne(pri => pri.ProductVariant)
                .WithMany()
                .HasForeignKey(pri => pri.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductionRoutingItem>()
                .HasOne(pri => pri.ProductionRouting)
                .WithMany()
                .HasForeignKey(pri => pri.ProductionRoutingId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductionRoutingItem>()
                .HasOne(pri => pri.RoutingPurpose)
                .WithMany()
                .HasForeignKey(pri => pri.RoutingPurposeId)
                .OnDelete(DeleteBehavior.Restrict);

            // H. UserBranchAccess (Çözüldü: UserId ve BranchId birleşik anahtardır)
            modelBuilder.Entity<UserBranchAccess>()
                .HasKey(uba => new { uba.UserId, uba.BranchId });
            modelBuilder.Entity<UserBranchAccess>()
                .HasOne(uba => uba.User)
                .WithMany(l => l.BranchAccesses)
                .HasForeignKey(uba => uba.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserBranchAccess>()
                .HasOne(uba => uba.Branch)
                .WithMany()
                .HasForeignKey(uba => uba.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            // I. UserRolePermission (Çözüldü: UserRoleId ve PermissionId birleşik anahtardır)
            modelBuilder.Entity<UserRolePermission>()
                .HasKey(urp => new { urp.UserRoleId, urp.PermissionId });
            modelBuilder.Entity<UserRolePermission>()
                .HasOne(urp => urp.UserRole)
                .WithMany()
                .HasForeignKey(urp => urp.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRolePermission>()
                .HasOne(urp => urp.Permission)
                .WithMany()
                .HasForeignKey(urp => urp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);


            // -----------------------------------------------------------
            // C. GENEL TEK/ÇOK İLİŞKİLER (SHADOW KEY UYARILARI İÇİN AÇIK TANIMLAR)
            // -----------------------------------------------------------

            // Order/OrderLine - RootType (RootTypeId1 uyarısını çözer)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.RootType)
                .WithMany()
                .HasForeignKey(o => o.RootTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                // Varsayım: Order entity'nizde CreatedBy navigasyon property'si var
                .HasOne(o => o.CreatedBy)
                .WithMany() // User entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(o => o.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.RootType)
                .WithMany()
                .HasForeignKey(ol => ol.RootTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.LineStatus)
                .WithMany()
                .HasForeignKey(ol => ol.LineStatusId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.StockCurrency)
                .WithMany()
                .HasForeignKey(ol => ol.StockCurrencyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Order) // Varsayım: OrderLine entity'nizde Order navigasyon property'si var
                .WithMany(o => o.OrderLines) // Order entity'sinde OrderLines koleksiyonu olduğunu varsayıyoruz
                .HasForeignKey(ol => ol.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            // OrderAdditionalFee - AdditionalFeeDefinition (AdditionalFeeDefinitionId1 uyarısını çözer)
            modelBuilder.Entity<OrderAdditionalFee>()
                .HasOne(oaf => oaf.AdditionalFeeDefinition)
                .WithMany()
                .HasForeignKey(oaf => oaf.AdditionalFeeDefinitionId)
                .OnDelete(DeleteBehavior.Restrict);

            // OrderFulfillment - Status (StatusId1 uyarısını çözer)
            modelBuilder.Entity<OrderFulfillment>()
                .HasOne(of => of.Status)
                .WithMany()
                .HasForeignKey(of => of.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderFulfillment>()
                .HasOne(of => of.Order) // Varsayım: OrderFulfillment entity'nizde Order navigasyon property'si var
                .WithMany(o => o.Fulfillments) // Order entity'sinde Fulfillments koleksiyonu olduğunu varsayıyoruz
                .HasForeignKey(of => of.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Product - Brand (BrandId1 uyarısını çözer)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // WorkOrderOperation - WorkCenter (WorkCenterId1 uyarısını çözer)
            modelBuilder.Entity<WorkOrderOperation>()
                .HasOne(woo => woo.WorkCenter)
                .WithMany()
                .HasForeignKey(woo => woo.WorkCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            // CustomerMetalAccountTransaction - TransactionType (TransactionTypeId1 uyarısını çözer)
            modelBuilder.Entity<CustomerMetalAccountTransaction>()
                .HasOne(cmat => cmat.TransactionType)
                .WithMany()
                .HasForeignKey(cmat => cmat.TransactionTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            // -----------------------------------------------------------
            // D. ÖZEL BİREBİR/BİREÇOK İLİŞKİ ÇÖZÜMLERİ
            // -----------------------------------------------------------

            // Customer - MailingAddress (Billing/Shipping)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.BillingAddress)
                .WithMany()
                .HasForeignKey(c => c.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ShippingAddress)
                .WithMany()
                .HasForeignKey(c => c.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // MailingAddress.Customer ilişkisi (MailingAddress'teki CustomerId/Customer alanlarını hedefliyoruz)
            modelBuilder.Entity<MailingAddress>()
                .HasOne(ma => ma.Customer)
                .WithMany()
                .HasForeignKey(ma => ma.CustomerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // BOM - ProductVariant (Birebir İlişki)
            modelBuilder.Entity<BillOfMaterials>()
                .HasOne(bom => bom.ProductVariant)
                .WithOne(pv => pv.BillOfMaterials)
                .HasForeignKey<BillOfMaterials>(bom => bom.ProductVariantId)
                .OnDelete(DeleteBehavior.NoAction);

            // -----------------------------------------------------------
            // J. ÜRETİM SİPARİŞİ VE İŞLEM İLİŞKİSİ
            // -----------------------------------------------------------

            // ProductionTransaction'dan ProductionOrder'a giden bire-çok ilişkiyi tanımla
            modelBuilder.Entity<ProductionTransaction>()
                .HasOne(pt => pt.ProductionOrder) // Transaction'ın tek bir ProductionOrder'ı var
                .WithMany(po => po.Transactions)  // ProductionOrder'ın birden çok Transaction'ı var
                                                  // Yabancı anahtarın (Foreign Key) ProductionTransaction entitesinde olduğunu belirtiyoruz
                .HasForeignKey(pt => pt.ProductionOrderId)
                .OnDelete(DeleteBehavior.NoAction); // Sipariş silinirse, hareketler de silinsin.
            modelBuilder.Entity<ProductionTransaction>()
                // Varsayım: ProductionTransaction entity'nizde Unit navigasyon property'si var
                .HasOne(pt => pt.Unit)
                .WithMany() // UnitOfMeasure entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(pt => pt.UnitId)
                .OnDelete(DeleteBehavior.NoAction);

            // -----------------------------------------------------------
            // K. İŞ MERKEZİ OPERASYON İLİŞKİSİ (BİRLEŞİK ANAHTAR)
            // -----------------------------------------------------------

            // WorkCenterOperation için birleşik anahtar tanımlama: WorkCenterId ve OperationDefinitionId
            modelBuilder.Entity<WorkCenterOperation>()
                .HasKey(wco => new { wco.WorkCenterId, wco.OperationDefinitionId });

            // WorkCenter silinirse kayıtlar silinsin
            modelBuilder.Entity<WorkCenterOperation>()
                .HasOne(wco => wco.WorkCenter)
                .WithMany(wc => wc.AllowedOperations) // WorkCenter.cs'te AllowedOperations koleksiyonu var
                .HasForeignKey(wco => wco.WorkCenterId)
                .OnDelete(DeleteBehavior.Cascade);

            // OperationDefinition silinirse kayıtlar silinsin
            modelBuilder.Entity<WorkCenterOperation>()
                .HasOne(wco => wco.OperationDefinition)
                .WithMany()
                .HasForeignKey(wco => wco.OperationDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);

            // -----------------------------------------------------------
            // Z. CASCADE YOLU ÇÖZÜMÜ: ProductVariant - UnitOfMeasure
            // -----------------------------------------------------------

            // ProductVariant ile UnitOfMeasure arasındaki BaseUnitId FK'sindeki CASCADE sorununu çözer.
            // SQL Server'ın "Çoklu Cascade Yolu" hatasını engellemek için CASCADE'i NO ACTION (Restrict) olarak değiştiriyoruz.
            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.StockUnit)
                .WithMany() // UnitOfMeasure entitesinde bu koleksiyonu tanımlamadığınızı varsayarak WithMany() kullandık
                .HasForeignKey(pv => pv.StockUnitId)
                .OnDelete(DeleteBehavior.NoAction); // *** KRİTİK DEĞİŞİKLİK: CASCADE YERİNE RESTRICT ***

            // Diğer ProductVariant ilişkilerini de güvenlik için kontrol edelim:

            // ProductVariant - Product (Bu, genelde CASCADE kalabilir)
            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.Variants) // Product.cs içinde Variants koleksiyonu olduğunu varsayıyoruz.
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UnitOfMeasure>()
                .HasOne(u => u.UomType)
                .WithMany()
                .HasForeignKey(u => u.UomTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UnitOfMeasure>()
                .HasOne(u => u.BaseUnit)
                .WithMany(u => u.RelatedUnits)
                .HasForeignKey(u => u.BaseUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UnitOfMeasureConversion>()
                .HasOne(umc => umc.FromUnit)
                .WithMany()
                .HasForeignKey(umc => umc.FromUnitId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UnitOfMeasureConversion>()
                .HasOne(umc => umc.ToUnit)
                .WithMany()
                .HasForeignKey(umc => umc.ToUnitId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BOMStone>()
                .HasOne(bs => bs.Bom) // Varsayım: BOMStones'ta Bom navigasyon property'si var
                .WithMany(bom => bom.Stones) // Varsayım: BillOfMaterials'ta Stones koleksiyonu var
                .HasForeignKey(bs => bs.BomId)
                .OnDelete(DeleteBehavior.Restrict); // <-- Bunu Restrict yapın

            modelBuilder.Entity<BOMLabor>()
                .HasOne(bl => bl.Bom) // Varsayım: BOMLabor entity'sinde Bom navigasyonu var
                .WithMany()
                .HasForeignKey(bl => bl.BomId)
                .OnDelete(DeleteBehavior.NoAction); // <-- NoAction olarak ayarlanmalı
            modelBuilder.Entity<Branch>()
                // Assuming Branches entity has DefaultMetalLocation property
                .HasOne(b => b.DefaultMetalLocation)
                .WithMany() // Locations entity'sinde Branch koleksiyonu yoksa WithMany() kullanılır
                .HasForeignKey(b => b.DefaultMetalLocationId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.OwnCompany) // Varsayım: Branch entity'nizde OwnCompany navigasyon property'si var
                .WithMany(oc => oc.Branches) // OwnCompany entity'sinde Branches koleksiyonu olduğunu varsayıyoruz
                .HasForeignKey(b => b.OwnCompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RefiningProcess>()
                // RefiningProcess entity'nizde OutputKarat navigasyon property'si olduğunu varsayıyoruz
                .HasOne(rp => rp.OutputKarat)
                .WithMany() // Karat entity'sinde ilgili koleksiyon tanımlanmamışsa
                .HasForeignKey(rp => rp.OutputKaratId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderMetalSummary>()
                .HasOne(oms => oms.Order) // Varsayım: OrderMetalSummary entity'nizde Order navigasyon property'si var
                .WithMany() // Order entity'sinde OrderMetalSummaries koleksiyonu varsa burayı güncelleyin
                .HasForeignKey(oms => oms.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderPaymentLine>()
                .HasOne(opl => opl.Order) // Varsayım: OrderPaymentLine entity'nizde Order navigasyon property'si var
                .WithMany() // Order entity'sinde OrderPaymentLines koleksiyonu varsa burayı güncelleyin
                .HasForeignKey(opl => opl.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InvoiceLine>()
                // Varsayım: InvoiceLine entity'nizde Unit navigasyon property'si var
                .HasOne(il => il.Unit)
                .WithMany() // UnitOfMeasure entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(il => il.UnitId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderLineCost>()
                .HasOne(olc => olc.OrderLine) // Varsayım: OrderLineCost entity'nizde OrderLine navigasyon property'si var
                .WithMany() // OrderLine entity'sinde OrderLineCost koleksiyonu varsa burayı güncelleyin
                .HasForeignKey(olc => olc.OrderLineId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.MetalCurrency)
                .WithMany() // Currency entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(st => st.MetalCurrencyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.Location)
                .WithMany() // Location entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(st => st.LocationId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.CreatedBy)
                .WithMany() // User entity'sinde ilgili koleksiyonu tanımlamadığınızı varsayarak
                .HasForeignKey(st => st.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<WorkOrderOperationLog>()
                .HasOne(wol => wol.Operation)
                .WithMany()
                .HasForeignKey(wol => wol.OperationId)
                .OnDelete(DeleteBehavior.NoAction);



            //SEED ler
            modelBuilder.Entity<UomType>().HasData(
                new UomType { Id = 1, Name = "Ağırlık", Code = "WEIGHT" },
                new UomType { Id = 2, Name = "Adet", Code = "COUNT" },
                new UomType { Id = 3, Name = "Uzunluk", Code = "LENGTH" },
                new UomType { Id = 4, Name = "Hacim", Code = "VOLUME" }
            );


            // İlişki çakışmalarını önlemek için (EF Core'un otomatik oluşturduğu gereksiz cascade delete'leri kaldırma)
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
