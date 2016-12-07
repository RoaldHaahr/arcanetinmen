using ArcaneTinmen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArcaneTinmen.DAL;

namespace ArcaneTinmen.ViewModels
{
    public class Cart
    {
            private List<CartLine> lines = new List<CartLine>();

            public decimal TotalPrice
            {
                // Linq syntax
                get { return lines.Sum(s => s.Sleeve.SalePrice * s.Quantity); }
            }

            public List<CartLine> Lines { get { return lines; } }

            public Cart() { }

            public void AddItem(Sleeve sleeve, int quantity)
            {

                CartLine item = lines.Where(s => s.Sleeve.SleeveId == sleeve.SleeveId).FirstOrDefault();

                if (item == null)
                {
                    lines.Add(new CartLine { Sleeve = sleeve, Quantity = quantity });
                }
                else
                {
                    item.Quantity += quantity;
                }
            }

            public void RemoveItem(Sleeve sleeve)
            {
                lines.RemoveAll(i => i.Sleeve.SleeveId == sleeve.SleeveId);
            }

            public void Clear()
            {
                lines.Clear();
            }
        }

        public class CartLine
        {
            public Sleeve Sleeve { get; set; }
            public int Quantity { get; set; }
        }

}
