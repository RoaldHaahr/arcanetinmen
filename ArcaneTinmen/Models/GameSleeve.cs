using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcaneTinmen.Models
{
    public class GameSleeve
    {
        // PROPERTIES
        //[Key]
        //public int GameSleeveId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0), Key]
        [Required]
        public string SleeveId { get; set; }
        [Column(Order = 1), Key]
        [Required]
        public int GameId { get; set; }

        // NAVIGATION
        public virtual Sleeve Sleeve { get; set; }
        public virtual Game Game { get; set; }

        // CONSTRUCTORS
        public GameSleeve() {}

        public GameSleeve(string sleeveId, int gameId)
        {
            SleeveId = sleeveId;
            GameId = gameId;
        }
    }
}