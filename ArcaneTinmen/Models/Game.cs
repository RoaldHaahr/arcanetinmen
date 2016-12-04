using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Game
    {
        [Required]
        public int GameId { get; set; }
        [Required]
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