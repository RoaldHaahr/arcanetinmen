using ArcaneTinmen.DAL;
using ArcaneTinmen.ViewModels;
using System.Linq;
using System.Web.Mvc;
using ArcaneTinmen.Models;
using System.Collections.Generic;

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
                Sleeves = db.Sleeves.ToList()
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

            List<string> games;
            List<string> sleeves;


            games = db.Games.Where(x => x.Name.StartsWith(term))
                .Select(y => y.Name )
                .ToList();

            /* 
             *  Replace for multi value + id
             *  */
               
               sleeves = db.Games.Where(x => x.Name.StartsWith(term))
                  .Select(s => s.SleeveId)
                  .ToList();

            var sendmeplz = db.Games.Where(x => x.Name.StartsWith(term)).
                Select(y => new { label = y.Name, cool = y.SleeveId}).ToArray();

             

               return Json(sendmeplz, JsonRequestBehavior.AllowGet);   

              
            /*
            return Json(games, JsonRequestBehavior.AllowGet); */

        }
    }
}