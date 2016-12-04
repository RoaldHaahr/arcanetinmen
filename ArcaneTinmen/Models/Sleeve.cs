using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Sleeve
    {
        [Key]
        public int SleeveId { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a height in millimeters")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Please enter a width in millimeters")]
        public int Width { get; set; }
        // Why is there both a cost- and a saleprice?
        public decimal CostPrice { get; set; }
        [Required(ErrorMessage = "Please enter the price for the sleeve")]
        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Please enter the amount of sleeves in stock")]
        public int StockAmount { get; set; }
        // Active property to determine, whether to list a product

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<GameSleeve> GameSleeves { get; set; }

        public Sleeve() {}

        public Sleeve(int sleeveId, string description, int height, int width, decimal costPrice, decimal salePrice, int stockAmount)
        {
            SleeveId = sleeveId;
            Description = description;
            Height = height;
            Width = width;
            CostPrice = costPrice;
            SalePrice = salePrice;
            StockAmount = stockAmount;
        }
    }
}