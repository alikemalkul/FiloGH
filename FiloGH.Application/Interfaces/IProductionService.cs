using FiloGH.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace FiloGH.Application.Interfaces
{
    public interface IProductionService
    {
        /// <summary>
        /// Onaylanmış bir siparişten veya stok talebinden yeni bir İş Emri (WorkOrder) oluşturur.
        /// </summary>
        /// <param name="sourceId">Sipariş ID'si veya stok talebi ID'si.</param>
        /// <param name="sourceType">Kaynak türü (ORDER, STOCK_REQUEST).</param>
        /// <param name="employeeId">İş emrini oluşturan personel.</param>
        /// <returns>Oluşturulan WorkOrder nesnesi.</returns>
        Task<WorkOrder> CreateWorkOrderFromSourceAsync(int sourceId, string sourceType, byte employeeId);

        /// <summary>
        /// Bir iş emri operasyonunun (aşamasının) başlatılmasını kaydeder.
        /// </summary>
        Task<bool> StartOperationAsync(int operationId, byte employeeId);

        /// <summary>
        /// Bir iş emri operasyonunun (aşamasının) tamamlanmasını kaydeder.
        /// </summary>
        /// <param name="metalOutputWeight">Operasyon sonunda çıkan fiili metal ağırlığı.</param>
        Task<bool> CompleteOperationAsync(int operationId, byte employeeId, decimal metalOutputWeight);

        /// <summary>
        /// Çalışanların bir operasyon üzerindeki zaman ve metal ayarlaması (ekleme/fire) logunu kaydeder.
        /// </summary>
        Task<WorkOrderOperationLog> LogTimeAndMetalAdjustmentAsync(int operationId, byte employeeId, DateTimeOffset startTime, DateTimeOffset endTime, decimal metalAdjustmentWeight, string adjustmentType, string? notes);

        // Sorgu Metotları
        Task<WorkOrder?> GetWorkOrderDetailsAsync(int workOrderId);
        Task<decimal> GetTotalMetalIssuedToWorkOrderAsync(int workOrderId);
    }
}
