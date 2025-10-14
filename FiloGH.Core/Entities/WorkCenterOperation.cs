using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// Bir İş Merkezinde (WorkCenter) hangi Operasyon Türlerinin (OperationDefinition) yapılabileceğini eşleştiren ara tablodur (Many-to-Many).
    /// </summary>
    public class WorkCenterOperation
    {
        // --- BİRLEŞİK ANAHTAR ---
        public byte WorkCenterId { get; set; }
        public required WorkCenter WorkCenter { get; set; } = null!;

        public byte OperationDefinitionId { get; set; }
        public required OperationDefinition OperationDefinition { get; set; } = null!;

        // --- EK ÖZELLİKLER (Opsiyonel olarak bu ilişkiye özel veriler) ---

        /// <summary>
        /// Bu özel eşleşme için operasyonun standart maliyetini geçersiz kılar.
        /// </summary>
        [Column(TypeName = "decimal(19,4)")] 
        public decimal? OverrideCostRate { get; set; }

        /// <summary>
        /// Bu eşleşmenin şu anda aktif olup olmadığı.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}