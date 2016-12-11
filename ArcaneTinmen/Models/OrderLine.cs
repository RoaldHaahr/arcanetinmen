using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        [Required]
        public int OrderPlacementId { get; set; }
        [Required]
        public string SleeveId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [ForeignKey("OrderPlacementId")]
        public OrderPlacement OrderPlacement { get; set; }
        [ForeignKey("SleeveId")]
        public Sleeve Sleeve { get; set; }

        public OrderLine(int orderPlacementId, string sleeveId, int quantity)
        {
            OrderPlacementId = orderPlacementId;
            SleeveId = sleeveId;
            Quantity = quantity;
        }
    }
}