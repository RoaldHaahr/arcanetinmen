using System.Collections.Generic;

namespace ArcaneTinmen.Models
{
    public class Sleeve
    {
        public int SleeveId { get; set; }
        public string Description { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        // Why is there both a cost- and a saleprice?
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int StockAmount { get; set; }

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