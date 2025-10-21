using System.ComponentModel.DataAnnotations;

namespace FiloGH.Application.DTOs.Order
{
    public record OrderCreateDto
    {
        // ---------------------------------------------------
        // Sipariş Temel Bilgileri (Order Entity'den)
        // ---------------------------------------------------

        // Siparişin ait olduğu şube kimliği (Order Entity'de zorunlu) [2, 7].
        [Required(ErrorMessage = "Şube kimliği zorunludur.")]
        public required byte BranchId { get; init; }

        // Siparişin işlem gördüğü para birimi kimliği (Order Entity'de zorunlu) [2, 7].
        [Required(ErrorMessage = "Para birimi zorunludur.")]
        public required byte CurrencyId { get; init; }

        // Siparişin oluşturulma tarihi (Order Entity'de zorunlu) [2, 8].
        public required DateTimeOffset OrderDate { get; init; }

        // İstenen teslimat tarihi (Order Entity'de opsiyonel) [8].
        public DateTimeOffset? RequiredDate { get; init; }

        // Müşteri Kimliği (Order Entity'de int? olarak opsiyoneldir) [2, 7].
        public int? CustomerId { get; init; }

        // Vergilerin fiyata dahil olup olmadığı (Order Entity'de zorunlu) [2, 5].
        public required bool TaxesIncluded { get; init; }

        // Sipariş Notu (Order Entity'de MaxLength(255) ile opsiyonel) [2, 5, 9].
        [MaxLength(255)]
        public string? Note { get; init; }

        // Teslimat ve Fatura Adres Kimlikleri (MailingAddress Entity'sine bağlıdır) [5]
        public int? ShippingAddressId { get; init; }
        public int? BillingAddressId { get; init; }

        // ---------------------------------------------------
        // Sipariş Kalemleri (Lines)
        // ---------------------------------------------------

        // Sipariş kalemlerinin listesi (OrderLine Entity'sine maplenir) [2].
        public required ICollection<OrderLineCreateDto> Lines { get; init; } = new List<OrderLineCreateDto>();
    }
}
