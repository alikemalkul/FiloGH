// FiloGH.Core/Entities/OrderLineType.cs (İsim güncellendi)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiloGH.Core.Entities
{
    /// <summary>
    /// OrderLine'ın ne tür bir kalem olduğunu (Ürün, Hizmet, İndirim vb.) tanımlar.
    /// </summary>
    public class OrderLineType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(20)]
        public required string Code { get; set; }

        /// <summary>
        /// Bu satır tipinin toplam tutara pozitif (+1) mi yoksa negatif (-1) mi etki edeceğini belirtir.
        /// </summary>
        public short MovementSign { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
}