using FiloGH.Application.DTOs;
using FiloGH.Application.Interfaces;
using FiloGH.Core.Entities;
using FiloGH.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FiloGH.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const byte StatusPendingId = 1;
        private const byte StatusConfirmedId = 2;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateNewOrderAsync(OrderCreateDto orderDto)
        {
            // =================================================================================
            // ZORUNLU İLİŞKİLİ NESNELERİN GEÇİCİ OLARAK OLUŞTURULMASI (Required Zinciri Kırıcı)
            // =================================================================================

            // 1. User (CreatedBy): required alanları içerir.
            var tempUser = new User
            {
                Id = 1,
                Username = "TEMP_USER",
                PasswordHash = "TEMP_HASH",
                FirstName = "TEMP_FIRSTNAME",
                LastName = "TEMP_LASTNAME",
                PrimaryBranch = null!,
                UserRole = null!
                // SecurityStamp yok varsayımı devam ediyor.
            };

            // 2. OwnCompany (Branch Required): Name ve Code gereklidir.
            var tempOwnCompany = new OwnCompany
            {
                Id = 1,
                Name = "TEMP Company Name",
                TaxOffice = null!,
                TaxNumber = null!,
                BaseCurrency = null!,
            };

            // 3. Location (Branch Required): Name ve Code gereklidir.
            var tempCashLocation = new Location { Id = 1, Name = "TEMP Cash Loc" };
            var tempMetalLocation = new Location { Id = 2, Name = "TEMP Metal Loc" };

            // 4. Branch (Order Required): Tüm alt zorunluluklar tamamlanmıştır.
            var tempBranch = new Branch
            {
                Id = orderDto.BranchId,
                Name = "TEMP Branch Name",
                Code = "TEMP01",
                OwnCompanyId = tempOwnCompany.Id,
                OwnCompany = tempOwnCompany,
                DefaultCashLocationId = tempCashLocation.Id,
                DefaultCashLocation = tempCashLocation,
                DefaultMetalLocationId = tempMetalLocation.Id,
                DefaultMetalLocation = tempMetalLocation,
            };

            // 5. Durumlar
            var tempCurrency = new Currency { Id = orderDto.CurrencyId, Code = "TMP", Name = "TEMP Currency Name" };
            var tempStatus = new OrderStatusDefinition { Id = StatusPendingId, Name = "TEMP Status Name", Code = "PEND" };
            var tempPaymentStatus = new OrderPaymentStatus { Id = 1, Name = "TEMP Payment Status", Code = "UNPD" };
            var tempRootType = new RootType { Id = 1, Name = "TEMP Root Type", Code = "SALE" };


            var newOrder = new Order
            {
                // İlişkili Nesneler (Required)
                Branch = tempBranch,
                Currency = tempCurrency,
                Status = tempStatus,
                OrderPaymentStatus = tempPaymentStatus,
                CreatedBy = tempUser,
                RootType = tempRootType,

                // Temel Alanlar
                OrderNumber = Guid.NewGuid().ToString().Substring(0, 10),
                OrderDate = orderDto.OrderDate,
                CustomerId = orderDto.CustomerId,
                CurrencyId = orderDto.CurrencyId,
                StatusId = StatusPendingId,
                OrderPaymentStatusId = tempPaymentStatus.Id,
                RootTypeId = tempRootType.Id,
                BranchId = orderDto.BranchId,
                TaxesIncluded = orderDto.TaxesIncluded,
                Note = orderDto.Note,

                // Audit Alanları
                CreatedById = tempUser.Id,
                CreatedAt = DateTimeOffset.UtcNow,

                OrderLines = new List<OrderLine>(),
            };

            // Satırları dönüştürme ve OrderLine/ProductVariant Hatalarını Giderme
            foreach (var lineDto in orderDto.Lines)
            {
                // ProductVariant için zorunlu alanlar: Code, Name
                var tempProductVariant = new ProductVariant
                {
                    Id = lineDto.ProductVariantId,
                    Name = "TEMP Product Variant Name",
                    StockUnit = null!,
                    MetalColor = null!,
                    MetalPurity = null!,
                    Product = null!,
                    SKU = null!
                };

                var newOrderLine = new OrderLine
                {
                    // OrderLine Temel Alanları
                    ProductVariantId = lineDto.ProductVariantId,
                    StockQuantity = lineDto.Quantity,
                    UnitPrice = lineDto.UnitPrice,

                    // OrderLine Zorunlu İlişkileri
                    Order = newOrder,
                    ProductVariant = tempProductVariant,
                    LineType = null!,
                    CustomerCurrency = null!,
                    LineStatus = null!,
                    RootType = null!,
                    StockCurrency = null!
                };
                newOrder.OrderLines.Add(newOrderLine);
            }

            var orderRepository = _unitOfWork.GetRepository<Order, int>();
            await orderRepository.AddAsync(newOrder);

            await _unitOfWork.SaveAsync();

            return newOrder;
        }

        public async Task<bool> ConfirmOrderAsync(int orderId, int employeeId)
        {
            var orderRepository = _unitOfWork.GetRepository<Order, int>();

            // DÜZELTME: Bu nesne güncelleneceği için disableTracking: false (varsayılan) bırakıldı.
            var orders = await orderRepository.GetAllAsync(
                filter: o => o.Id == orderId,
                include: i => i.Include(o => o.OrderLines!)
            );
            var order = orders.FirstOrDefault();

            if (order == null || order.StatusId != StatusPendingId) return false;

            // Stok/Muhasebe Mantığı Buraya Gelir

            order.StatusId = StatusConfirmedId;
            order.UpdatedById = (byte)employeeId;
            order.UpdatedAt = DateTimeOffset.UtcNow;
            orderRepository.Update(order);

            return await _unitOfWork.SaveAsync() > 0;
        }

        public async Task<Order?> GetOrderDetailsAsync(int orderId)
        {
            var orderRepository = _unitOfWork.GetRepository<Order, int>();

            // KRİTİK DÜZELTME: Salt okunur işlem olduğu için AsNoTracking (disableTracking: true) kullanıldı.
            var orders = await orderRepository.GetAllAsync(
        filter: o => o.Id == orderId,
        include: i => i.Include(o => o.Customer)
               .Include(o => o.OrderLines!)
                 .ThenInclude(ol => ol.ProductVariant)
               .Include(o => o.Currency)
               .Include(o => o.Status),
                disableTracking: true
      );

            return orders.FirstOrDefault();
        }

        public Task<Invoice> CreateInvoiceFromOrderAsync(int orderId, int employeeId) { throw new NotImplementedException(); }
        public Task<decimal> GetCustomerMetalBalanceAsync(int customerId, byte metalTypeId) { throw new NotImplementedException(); }
        public Task UpdateOrderAsync(OrderCreateDto orderDto) { throw new NotImplementedException(); }
        public Task<bool> CancelOrderAsync(int orderId, int employeeId, string reason) { throw new NotImplementedException(); }
    }
}
