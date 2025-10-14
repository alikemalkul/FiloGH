using System.ComponentModel.DataAnnotations;

namespace FiloGH.Models.Entities
{
    public class Unit
    {
        public byte Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        /// <summary>
        /// gr, stk, %
        /// </summary>
        [MaxLength(10)]
        public required string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
