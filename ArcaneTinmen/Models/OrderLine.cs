using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        public string SleeveId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get { return Quantity * Sleeve.SalePrice; } }


        //[ForeignKey("SleeveId")]
        public virtual Sleeve Sleeve { get; set; }

        public OrderLine() { }

        public OrderLine(Sleeve sleeve, int quantity)
        {
            Sleeve = sleeve;
            Quantity = quantity;
        }

        public OrderLine(int orderLineId, Sleeve sleeve, int quantity)
        {
            OrderLineId = orderLineId;
            Sleeve = sleeve;
            Quantity = quantity;
        }

    }
}