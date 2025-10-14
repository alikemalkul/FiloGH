// FiloGH.Core/Entities/InvoiceStatus.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir Fatura'nın yasal ve operasyonel durumunu tanımlar (Kesildi, İptal Edildi, E-Fatura Gönderildi vb.).
    /// </summary>
    public class InvoiceStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // byte optimizasyonu

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Durumun nihai ve değiştirilemez olup olmadığı (Örn: İptal Edildi, Tahsil Edildi).
        /// </summary>
        public bool IsFinal { get; set; } = false;

        /// <summary>
        /// Bu durumun, faturanın yasal olarak resmi kurumlara gönderildiğini gösterip göstermediği.
        /// </summary>
        public bool IsLegalSubmission { get; set; } = false;

        public bool IsActive { get; set; } = true;
    }
}