using FiloGH.Application.DTOs;
using FiloGH.Application.DTOs.Order;
using FiloGH.Core.Entities;
using System.Threading.Tasks;

namespace FiloGH.Application.Interfaces
{
    /// <summary>
    /// Ana iş akışlarını (sipariş oluşturma, güncelleme, durum değiştirme) yönetir.
    /// Veri erişim detaylarından (Repository/DB) tamamen bağımsızdır.
    /// </summary>
    public interface IOrderService
    {
        // CRUD: Temel Sipariş Oluşturma
        Task<Order> CreateNewOrderAsync(OrderCreateDto orderDto);

        // İşlem: Sipariş durumunu onaylandı olarak değiştirir ve stok/muhasebe işlemlerini tetikler.
        Task<bool> ConfirmOrderAsync(int orderId, int employeeId);

        // İşlem: Siparişi Faturaya Çevirme (Muhasebe kaydını keser)
        Task<Invoice> CreateInvoiceFromOrderAsync(int orderId, int employeeId);

        // Sorgu: Müşterinin açık metal alacağını hesaplar (Karmaşık İş Mantığı)
        Task<decimal> GetCustomerMetalBalanceAsync(int customerId, byte metalTypeId);

        // Sorgu: Sipariş detaylarını tüm ilişkileriyle (OrderLines, Customer, Payment) getirir.
        Task<Order?> GetOrderDetailsAsync(int orderId);

        // CRUD: Basit sipariş güncelleme (Şimdilik boş bir DTO ile bırakıyorum)
        Task UpdateOrderAsync(OrderCreateDto orderDto);

        // CRUD: Siparişi iptal etme
        Task<bool> CancelOrderAsync(int orderId, int employeeId, string reason);
    }
}
