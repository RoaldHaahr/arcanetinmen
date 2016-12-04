using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class GameSleeve
    {
        //[Key]
        //public int GameSleeveId { get; set; }
        [Column(Order = 0), Key]
        [Required]
        public int SleeveId { get; set; }
        [Column(Order = 1), Key]
        [Required]
        public int GameId { get; set; }

        public Sleeve Sleeve { get; set; }
        public Game Game { get; set; }

        public GameSleeve() {}

        public GameSleeve(int sleeveId, int gameId)
        {
            SleeveId = sleeveId;
            GameId = gameId;
        }
    }
}