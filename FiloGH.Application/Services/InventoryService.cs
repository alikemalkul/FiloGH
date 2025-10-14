using FiloGH.Core.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Application.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic; // IEnumerable için gerekli

namespace FiloGH.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Gerekli varsayılan ID'ler (Örn: Metal Currency ID'si 1 olsun)
        private const byte GoldCurrencyId = 1;
        private const byte BaseCurrencyEURId = 2; // Maliyet baz alınacak döviz

        public InventoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // =================================================================
        // İŞLEM: Yeni Stok Hareketi Kaydetme
        // =================================================================

        public async Task<StockTransaction> RecordTransactionAsync(
      byte movementTypeId,
      byte branchId,
      byte locationId,
      byte? metalPurityId,
      decimal weightInGrams,
      string sourceDocType,
      int? sourceDocId,
      byte createdById
    )
        {
            // --- TEMPORARY (GEÇİCİ) NESNELER OLUŞTURMA (EF Core Navigasyon Hatalarını Önlemek İçin) ---

            var tempUser = new User
            {
                Id = createdById,
                Username = "INV_USER",
                PasswordHash = "TEMP",
                FirstName = "TEMP_F",
                LastName = "TEMP_L",
                PrimaryBranch = null!,
                UserRole = null!
            };

            var tempMovementType = new StockMovementType
            {
                Id = movementTypeId,
                Name = "TEMP_MOVE",
                Code = "TEMP",
                Sign = (short)(weightInGrams > 0 ? 1 : (weightInGrams < 0 ? -1 : 0))
            };

            var tempBranch = new Branch
            {
                Id = branchId,
                Name = "TEMP Branch",
                Code = "TMPBR",
                OwnCompanyId = 1,
                OwnCompany = null!,
                DefaultCashLocation = null!,
                DefaultMetalLocation = null!
            };

            var tempLocation = new Location
            {
                Id = locationId,
                Name = "TEMP Location"
            };

            var tempMetalCurrency = new Currency
            {
                Id = GoldCurrencyId,
                Code = "GOLD",
                Name = "Gold Gram"
            };

            var tempBaseCurrency = new Currency
            {
                Id = BaseCurrencyEURId,
                Code = "EUR",
                Name = "Euro"
            };

            // 7. MetalPurity Yönetimi
            MetalPurity? tempPurity = null;
            decimal transactionFineness = 1.0M; // Varsayılan Saf (999.9)

            if (metalPurityId.HasValue)
            {
                var purityRepository = _unitOfWork.GetRepository<MetalPurity, byte>();

                // Gerçek nesneyi çekmeye çalış. Salt okunur olduğu için disableTracking: true kullanıldı.
                tempPurity = await purityRepository.GetByIdAsync(metalPurityId.Value, disableTracking: true);

                if (tempPurity != null)
                {
                    transactionFineness = tempPurity.PurityRatio;
                }
                else
                {
                    // Nesne bulunamazsa, sadece ID'sini set eden geçici bir nesne oluştur.
                    tempPurity = new MetalPurity { Id = metalPurityId.Value, PurityRatio = 0.585M, BaseMetal = null!, Name = string.Empty };
                    transactionFineness = 0.585M;
                }
            }

            // --- YENİ HAREKET KAYDI OLUŞTURMA ---

            var newTransaction = new StockTransaction
            {
                // Required İlişkiler
                MovementTypeId = movementTypeId,
                MovementType = tempMovementType,
                BranchId = branchId,
                Branch = tempBranch,
                LocationId = locationId,
                Location = tempLocation,
                MetalCurrencyId = GoldCurrencyId,
                MetalCurrency = tempMetalCurrency,
                BaseExchangeCurrencyId = BaseCurrencyEURId,
                BaseExchangeCurrency = tempBaseCurrency,
                CreatedById = createdById,
                CreatedBy = tempUser,

                // Temel Alanlar
                TransactionDate = DateTimeOffset.UtcNow,
                ReferenceDocType = sourceDocType,

                // Metal ve Maliyet Bilgileri
                MetalPurityId = metalPurityId,
                MetalPurity = tempPurity,
                Fineness = transactionFineness,
                WeightInGrams = weightInGrams,

                // MALİYET HESAPLAMASI
                CostPerGramEUR = await GetAverageCostPerGramAsync(metalPurityId ?? 1, locationId),
                FixedExchangeRate = 1.0M,

                Notes = $"Hareket kaynağı: {sourceDocType} ID: {sourceDocId}"
            };

            // Repository'de tanımlı olan asenkron AddAsync çağrıldı.
            var transactionRepository = _unitOfWork.GetRepository<StockTransaction, long>();
            await transactionRepository.AddAsync(newTransaction);

            // İşlemi veritabanına kaydet
            await _unitOfWork.SaveAsync();

            return newTransaction;
        }

        // =================================================================
        // İŞLEM: Transfer Uygulaması
        // =================================================================

        public async Task<bool> TransferStockAsync(byte transferMovementTypeId, byte branchId, byte fromLocationId, byte toLocationId, decimal weightInGrams, int createdById)
        {
            if (weightInGrams <= 0)
            {
                throw new ArgumentException("Transfer ağırlığı pozitif olmalıdır.", nameof(weightInGrams));
            }

            // Not: Transfer işlemlerinde MetalPurityId kritik öneme sahiptir.
            // Mevcut metot imzasında Purity ID olmadığı için, RecordTransactionAsync'in 
            // kabul ettiği şekilde null olarak geçiyoruz, ancak gerçek uygulamada bu parametre eklenmelidir.
            byte? metalPurityId = null; // Varsayılan olarak null bırakıldı.

            // 1. Lokasyon A'dan ÇIKIŞ Hareketi
            await RecordTransactionAsync(
        movementTypeId: transferMovementTypeId,
        branchId: branchId,
        locationId: fromLocationId,
        metalPurityId: metalPurityId,
        weightInGrams: -weightInGrams, // Negatif ağırlık = ÇIKIŞ
                sourceDocType: "TRANSFER_OUT",
        sourceDocId: null,
        createdById: (byte)createdById
      );

            // 2. Lokasyon B'ye GİRİŞ Hareketi
            await RecordTransactionAsync(
        movementTypeId: transferMovementTypeId,
        branchId: branchId,
        locationId: toLocationId,
        metalPurityId: metalPurityId,
        weightInGrams: weightInGrams, // Pozitif ağırlık = GİRİŞ
                sourceDocType: "TRANSFER_IN",
        sourceDocId: null,
        createdById: (byte)createdById
      );

            return true;
        }

        // =================================================================
        // İŞLEM: Sorgular
        // =================================================================

        public async Task<decimal> GetAverageCostPerGramAsync(byte metalPurityId, int locationId)
        {
            var repository = _unitOfWork.GetRepository<StockTransaction, long>();

            // DÜZELTME: GetAllAsync kullanıldı ve ToListAsync kaldırıldı.
            // Salt okunur sorgu olduğu için disableTracking = true kullanılır.
            var allTransactions = await repository.GetAllAsync(
        filter: t => t.MetalPurityId == metalPurityId && t.LocationId == locationId,
        disableTracking: true
      );

            if (!allTransactions.Any()) return 0;

            // Bellekteki veriler üzerinde hesaplama yapılır.
            var totalCost = allTransactions.Sum(t => t.WeightInGrams * t.CostPerGramEUR);
            var currentStockWeight = allTransactions.Sum(t => t.WeightInGrams);

            // Mevcut stok ağırlığı pozitifse ortalamayı hesapla
            return currentStockWeight > 0 ? totalCost / currentStockWeight : 0;
        }

        public async Task<decimal> GetStockBalanceByPurityAsync(int locationId, byte metalPurityId)
        {
            var repository = _unitOfWork.GetRepository<StockTransaction, long>();

            // DÜZELTME: GetAllAsync kullanıldı ve SumAsync yerine in-memory Sum kullanıldı.
            // Veritabanı üzerinde sadece filtreleme yapıp SUM alarak performansı artırıyoruz.
            // disableTracking: true (salt okunur olduğu için)
            var allTransactions = await repository.GetAllAsync(
        filter: t => t.MetalPurityId == metalPurityId && t.LocationId == locationId,
        disableTracking: true
      );

            // Bellekteki veriler üzerinde SUM işlemi yapılır.
            var totalBalance = allTransactions.Sum(t => t.WeightInGrams);

            return totalBalance;
        }
    }
}
