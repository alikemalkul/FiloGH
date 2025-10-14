using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Fiziksel nakit kasalarını (Vezneler) veya şirket içi nakit hesaplarını (Petty Cash) tanımlar.
    /// </summary>
    public class Cash
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(10)]
        public required string Code { get; set; }

        /// <summary>
        /// Kasanın tuttuğu ana para birimi (TRY, EUR, USD).
        /// </summary>
        public byte CurrencyId { get; set; }
        public required Currency Currency { get; set; } = null!;

        /// <summary>
        /// Kasanın bulunduğu şube.
        /// </summary>
        public byte BranchId { get; set; }
        public required Branch Branch { get; set; } = null!;

        /// <summary>
        /// Bu kasanın Muhasebe Hesap Planındaki karşılığı (Örn: 100 Kasa Hesabı).
        /// </summary>
        public int AccountChartId { get; set; }
        public required AccountChart AccountChart { get; set; } = null!;

        /// <summary>
        /// Kasanın anlık toplam bakiyesi (Operasyonel bakiye).
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentBalance { get; set; } = 0.0M;

        public bool IsActive { get; set; } = true;
    }
}