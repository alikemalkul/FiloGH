
using FiloGH.Application.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FiloGH.Application.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private const byte StatusNewId = 1;
        private const byte OperationStatusStartedId = 2;
        private const byte OperationStatusCompletedId = 3;


        public ProductionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // =================================================================
        // CREATE: İş Emri Oluşturma
        // =================================================================

        public async Task<WorkOrder> CreateWorkOrderFromSourceAsync(int sourceId, string sourceType, byte employeeId)
        {
            if (sourceType != "ORDER")
            {
                throw new NotImplementedException("Şu anda sadece siparişten iş emri oluşturma desteklenmektedir.");
            }

            var orderRepository = _unitOfWork.GetRepository<Order, int>();

            // Sipariş detaylarını yükle
            var orders = await orderRepository.GetAllAsync(
        filter: o => o.Id == sourceId,
// DÜZELTME: CS8619 uyarısını gidermek için IIncludableQueryable<Order, object> türüne açıkça cast yapıldı.
                include: i => (IIncludableQueryable<Order, object>)i
          .Include(o => o.OrderLines!)
          .ThenInclude(ol => ol.ProductVariant)
      );

            // HATA DÜZELTİLDİ: orders artık IEnumerable<Order> olduğu için senkron FirstOrDefault() kullanılır.
            var order = orders.FirstOrDefault();

            if (order == null || order.OrderLines == null || !order.OrderLines.Any())
            {
                throw new InvalidOperationException($"Kaynak sipariş (ID: {sourceId}) bulunamadı veya satır içermiyor.");
            }

            var firstLine = order.OrderLines.First();

            // --- Gerekli İlişkiler İçin Yer Tutucu Nesneler (Mock) ---
            var tempUser = new User { Id = employeeId, Username = "TEMP", PasswordHash = "TEMP", FirstName = "T", LastName = "T", PrimaryBranch = null!, UserRole = null! };
            var tempStatus = new WorkOrderStatus { Id = StatusNewId, Code = "NEW", Name = "Yeni Oluşturuldu" };
            var tempProductVariant = new ProductVariant { Id = firstLine.ProductVariantId!.Value, Name = "TEMP", StockUnit = null!, MetalColor = null!, MetalPurity = null!, Product = null!, SKU = null! };

            var woRepository = _unitOfWork.GetRepository<WorkOrder, int>();

            var newWorkOrder = new WorkOrder
            {
                OrderId = order.Id,
                ProductVariantId = firstLine.ProductVariantId!.Value,
                ProductVariant = tempProductVariant,
                StatusId = StatusNewId,
                Status = tempStatus,
                CreatedById = employeeId,
                CreatedBy = tempUser,
                WorkOrderNumber = $"WO-{DateTime.Now.Year}-{sourceId}",
                CreatedDate = DateTimeOffset.UtcNow,
                DueDate = order.RequiredDate ?? DateTimeOffset.UtcNow.AddDays(7),
                Quantity = firstLine.StockQuantity,
                TargetMetalWeight = firstLine.StockQuantity * 5,
                IssuedMetalWeight = 0,
                CalculatedScrapWeight = 0,
                Operations = new List<WorkOrderOperation>(),
            };

            await woRepository.AddAsync(newWorkOrder);

            // Kaydetme (SaveAsync) işlemi Service dışında yapılacaktır.
            return newWorkOrder;
        }

        // =================================================================
        // İŞLEM: Operasyon Yönetimi (Başlatma ve Tamamlama)
        // =================================================================

        public async Task<bool> StartOperationAsync(int operationId, byte employeeId)
        {
            var operationRepository = _unitOfWork.GetRepository<WorkOrderOperation, int>();
            var operation = await operationRepository.GetByIdAsync(operationId);

            if (operation == null || operation.StatusId != StatusNewId)
            {
                return false;
            }

            operation.StatusId = OperationStatusStartedId;
            operation.StartedAt = DateTimeOffset.UtcNow;

            operationRepository.Update(operation);

            // Kaydetme (SaveAsync) işlemi Service dışında yapılacaktır.
            return true;
        }

        public async Task<bool> CompleteOperationAsync(int operationId, byte employeeId, decimal metalOutputWeight)
        {
            var operationRepository = _unitOfWork.GetRepository<WorkOrderOperation, int>();
            var operation = await operationRepository.GetByIdAsync(operationId);

            if (operation == null || operation.StatusId != OperationStatusStartedId)
            {
                return false;
            }

            operation.StatusId = OperationStatusCompletedId;
            operation.CompletedAt = DateTimeOffset.UtcNow;
            operation.MetalOutputWeight = metalOutputWeight;

            // İş Emri seviyesinde ağırlıkların güncellenmesi mantığı buraya eklenecek.

            operationRepository.Update(operation);

            // Kaydetme (SaveAsync) işlemi Service dışında yapılacaktır.
            return true;
        }

        // =================================================================
        // İŞLEM: Loglama ve Sorgular (CS1998 uyarısı temizlendi)
        // =================================================================

        public Task<WorkOrderOperationLog> LogTimeAndMetalAdjustmentAsync(int operationId, byte employeeId, DateTimeOffset startTime, DateTimeOffset endTime, decimal metalAdjustmentWeight, string adjustmentType, string? notes)
        {
            // Gerçek implementasyon buraya gelecek.
            throw new NotImplementedException();
        }

        public Task<WorkOrder?> GetWorkOrderDetailsAsync(int workOrderId)
        {
            // Gerçek implementasyon buraya gelecek.
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalMetalIssuedToWorkOrderAsync(int workOrderId)
        {
            // Gerçek implementasyon buraya gelecek.
            throw new NotImplementedException();
        }
    }
}
