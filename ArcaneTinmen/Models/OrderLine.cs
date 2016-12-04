using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        [Required]
        public int OrderPlacementId { get; set; }
        [Required]
        public int SleeveId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public OrderPlacement OrderPlacement { get; set; }
        public Sleeve Sleeve { get; set; }
    }
}