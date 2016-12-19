using ArcaneTinmen.DAL;
using ArcaneTinmen.ViewModels;
using System.Linq;
using System.Web.Mvc;
using ArcaneTinmen.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Collections;

namespace ArcaneTinmen.Controllers
{
    public class HomeController : Controller
    {
        private ArcaneTinmenContext db;

        // GET: Home
        public ActionResult Index()
        {
            db = new ArcaneTinmenContext();
            SleeveListViewModel model = new SleeveListViewModel
            {
                Sleeves = db.Sleeves.ToList(),
                Games = db.Games.ToList(),
                GameSleeves = db.GameSleeves.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            ArcaneTinmenContext db = new ArcaneTinmenContext();
            List<Game> games;

            if(string.IsNullOrEmpty(searchTerm))
            {
                games = db.Games.ToList();
            }
            else
            {
                games = db.Games.Where(x => x.Name.StartsWith(searchTerm)).ToList();
            }
            return View(games);            
        }

        public JsonResult GetGames(string term)
        {
            ArcaneTinmenContext db = new ArcaneTinmenContext();
           
            var games = db.Games.Where(g => g.Name.StartsWith(term)).Select(g => new { label = g.Name, value = g.GameSleeves.Select(gs => gs.SleeveId) }).ToArray();

            return Json(games, JsonRequestBehavior.AllowGet);   
        }
    }
}