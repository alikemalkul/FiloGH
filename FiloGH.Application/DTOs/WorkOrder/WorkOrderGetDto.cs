using System;
using FiloGH.Application.DTOs.MetalType;
using FiloGH.Application.DTOs.Product;
using FiloGH.Application.DTOs.WorkOrderStatus;

namespace FiloGH.Application.DTOs.WorkOrder
{
    /// <summary>
    /// İş Emri (Work Order) bilgilerini listeleme veya detay gösterme amaçlı kullanılan DTO.
    /// İlişkili Entity'lerin temel bilgilerini içerir.
    /// </summary>
    public record WorkOrderGetDto
    {
        public required int Id { get; init; }

        // İlişkili Ürün Bilgisi
        public required int ProductId { get; init; }
        public required ProductGetDto Product { get; init; }

        // İlişkili Metal Tipi Bilgisi
        public required byte MetalTypeId { get; init; }
        public required MetalTypeGetDto MetalType { get; init; }

        // İlişkili Durum Bilgisi
        public required byte StatusId { get; init; }
        public required WorkOrderStatusGetDto Status { get; init; }

        public required int Quantity { get; init; }

        public required DateTimeOffset PlannedStartDate { get; init; }
        public DateTimeOffset? PlannedCompletionDate { get; init; }
        public DateTimeOffset? ActualCompletionDate { get; init; }

        public string? ReferenceCode { get; init; }
        public string? Notes { get; init; }

        // İzleme Bilgileri
        public required DateTimeOffset CreatedAt { get; init; }
        public required int CreatedById { get; init; }
        public string? CreatedByName { get; init; }
        public DateTimeOffset? ModifiedAt { get; init; }
    }
}
