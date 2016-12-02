using System.Collections.Generic;

namespace ArcaneTinmen.Models
{
    public class GameSleeve
    {
        public int GameSleeveId { get; set; }
        public int SleeveId { get; set; }
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