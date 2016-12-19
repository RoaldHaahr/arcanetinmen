using System;
using System.Collections.Generic;
using ArcaneTinmen.Models;

namespace ArcaneTinmen.ViewModels
{
    public class SleeveListViewModel
    {
        public IEnumerable<Sleeve> Sleeves { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<GameSleeve> GameSleeves { get; set; }
    }
}