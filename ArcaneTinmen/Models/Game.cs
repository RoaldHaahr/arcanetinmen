using System.Collections.Generic;

namespace ArcaneTinmen.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameSleeve> GameSleeves{ get; set; }

        public Game() {}

        public Game(int gameId, string name)
        {
            GameId = gameId;
            Name = name;
        }
    }
}