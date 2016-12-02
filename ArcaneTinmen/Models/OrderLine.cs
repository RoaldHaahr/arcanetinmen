using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcaneTinmen.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderPlacementId { get; set; }
        public int SleeveId { get; set; }
        public int Quantity { get; set; }

        public OrderPlacement OrderPlacement { get; set; }
        public Sleeve Sleeve { get; set; }
    }
}