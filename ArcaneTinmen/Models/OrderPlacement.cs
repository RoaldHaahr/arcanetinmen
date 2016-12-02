using System;
using System.Collections.Generic;

namespace ArcaneTinmen.Models
{
    public class OrderPlacement
    {
        // Maybe Order or Invoice instead
        public int OrderPlacementId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DatePlaced { get; set; }
        public DateTime DateShipped { get; set; }
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}