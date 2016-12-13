using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ArcaneTinmen.DAL;

namespace ArcaneTinmen.Models
{
    public class Game
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<GameSleeve> GameSleeves{ get; set; }

        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        public List<string> Search(string searchName)
        {
            return db.Games.Where(s => s.Name.StartsWith(searchName, 
                System.StringComparison.OrdinalIgnoreCase )).Select(s => s.Name).ToList();
        }
        public Game() {}

        public Game(int gameId, string name)
        {
            GameId = gameId;
            Name = name;
        }
    }
}