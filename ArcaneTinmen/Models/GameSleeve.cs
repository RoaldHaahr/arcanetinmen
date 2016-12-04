using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class GameSleeve
    {
        [Required]
        public int SleeveId { get; set; }
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