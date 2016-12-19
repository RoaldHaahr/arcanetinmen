using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using ArcaneTinmen.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace ArcaneTinmen.Areas.Admin.Controllers
{
    public class GamesController : Controller
    {
        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        // GET: Admin/Games
        public ActionResult Index()
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            return View(db.Games.ToList());
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Name,GameSleeves")] Game game, string[] Sleeves)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            if (ModelState.IsValid)
            {
                game.GameSleeves = new List<GameSleeve>();
                db.Games.Add(game);

                foreach (string sleeveId in Sleeves)
                {
                    GameSleeve gs = db.GameSleeves.Create();
                    gs.GameId = game.GameId;
                    gs.SleeveId = sleeveId;

                    game.GameSleeves.Add(gs);
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(game);
        }

        [ChildActionOnly]
        public ActionResult GetSleeveSelect(IEnumerable<GameSleeve> gs = null)
        {
            SleeveListViewModel model = new SleeveListViewModel
            {
                Sleeves = db.Sleeves.ToList(),
                GameSleeves = gs
            };
            return PartialView("_SleeveSelect", model);
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Name,SleeveId")] Game game, string[] Sleeves)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;

                if(game.GameSleeves == null)
                {
                    game.GameSleeves = new List<GameSleeve>();
                }

                foreach(string sleeveId in Sleeves)
                {
                    GameSleeve gs = db.GameSleeves.Create();
                    gs.GameId = game.GameId;
                    gs.SleeveId = sleeveId;
                    game.GameSleeves.Add(gs);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login", "Accounts");

            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
