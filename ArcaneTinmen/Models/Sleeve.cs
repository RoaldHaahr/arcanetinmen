﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class Sleeve
    {
        // PROPERTIES
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SleeveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[Required(ErrorMessage = "Please enter a height in millimeters")]
        public int Height { get; set; }
        //[Required(ErrorMessage = "Please enter a width in millimeters")]
        public int Width { get; set; }
        //[Required(ErrorMessage = "Please enter the price for the sleeve")]
        public decimal SalePrice { get; set; }
        //[Required(ErrorMessage = "Please enter the amount of sleeves in stock")]
        public int StockAmount { get; set; }

        public bool ShowFrontPage { get; set; }

        public string CardImageFileName { get; set; }

        public string BadgeImageFileName { get; set; }

        // NAVIGATION
        //public List<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Sleeve> GameSleeves { get; set; }

        // CONSTRUCTORS
        public Sleeve() {}

        public Sleeve(string name, decimal saleprice)
        {
            Name = name;
            SalePrice = saleprice;
        }

        public Sleeve(string sleeveId, string name, string description, int height, int width, decimal salePrice, int stockAmount)
        {
            SleeveId = sleeveId;
            Name = name;
            Description = description;
            Height = height;
            Width = width;
            SalePrice = salePrice;
            StockAmount = stockAmount;
        }
    }
}