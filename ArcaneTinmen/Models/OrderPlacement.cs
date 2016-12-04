using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class OrderPlacement
    {
        // Maybe Order or Invoice instead
        [Key]
        public int OrderPlacementId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime DatePlaced { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateShipped { get; set; }
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}