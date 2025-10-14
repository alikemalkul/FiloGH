using System.Collections.Generic;
using System;

namespace FiloGH.Application.DTOs
{
    /// <summary>
    /// Yeni bir sipariş oluşturmak için UI'dan Servis katmanına veri taşıma nesnesi.
    /// </summary>
    public class OrderCreateDto
    {
        // İlişkili ID'ler
        public int CustomerId { get; set; }
        public byte CurrencyId { get; set; }
        public byte BranchId { get; set; } // Hangi şube için oluşturulduğu
        public int RootTypeId { get; set; } // Satış (SALE), Satın Alma (PURCHASE), vb.

        // Tarihler
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? RequiredDate { get; set; } // Müşteri/Tedarikçi tarafından istenen tarih
        public DateTimeOffset? DeliveryDateTarget { get; set; } // Tahmini teslimat tarihi

        // Adresler
        public int? ShippingAddressId { get; set; }
        public int? BillingAddressId { get; set; }

        // Diğer Ayarlar
        public bool TaxesIncluded { get; set; }
        public string? Note { get; set; }
        public string? Tags { get; set; }

        // Satırlar
        public List<OrderLineDto> Lines { get; set; } = new List<OrderLineDto>();
    }
}