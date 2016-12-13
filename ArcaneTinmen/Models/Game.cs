using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using ArcaneTinmen.DAL;


namespace ArcaneTinmen.Models
{
    public class Game
    {
        [Required]
        [Key]
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; }
      
        [Required]
        public string SleeveId { get; set; }


        public virtual ICollection<GameSleeve> GameSleeves{ get; set; }
        public Game() {}

        public Game(int gameId, string name)
        {
            GameId = gameId;
            Name = name;
        }
    }
}