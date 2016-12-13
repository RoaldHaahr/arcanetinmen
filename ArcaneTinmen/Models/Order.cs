using ArcaneTinmen.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class Order
    {
        private decimal totalPrice;
        private List<OrderLine> orderLines = new List<OrderLine>();

        // Maybe Order or Invoice instead
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime2")]
        //[Required]
        public DateTime DatePlaced { get;  set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateShipped { get; set; }
        public decimal TotalPrice {
            get
            {
                totalPrice = 0;
                foreach (OrderLine orderLine in orderLines)
                {
                    totalPrice += orderLine.TotalPrice;
                }
                return totalPrice;
            }
        }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderLine> OrderLines {
            get { return orderLines; }
            set { orderLines = value; }
        }

        public Order(){}

        public Order(DateTime datePlaced, Customer customer)
        {
            DatePlaced = datePlaced;
            Customer = customer;
        }
    }
}