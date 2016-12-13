using System.Web;
using System.Web.Mvc;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using System.IO;
using System;
using System.Text;
using System.Data;
using System.Net;
using System.Data.Entity;
using ArcaneTinmen.ViewModels;
using System.Linq;

namespace ArcaneTinmen.Controllers
{
    public class SleeveController : Controller
    {
        private ArcaneTinmenContext db;

        public SleeveController()
        {
            db = new ArcaneTinmenContext();
        }

        // GET: Sleeve
        public ActionResult Index()
        {
            return View(db.Sleeves.ToList());

        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleeve sleeve = db.Sleeves.Find(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            return View(sleeve);
        }

        public ActionResult Create()
        {
            if (Session["AdminId"] == null)
            {
                ViewBag.Message = "Please login to create a new sleeve";
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sleeve sleeve)
        {
            if (Session["AdminId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Sleeves.Add(sleeve);
                    db.SaveChanges();
                    ViewBag.Message = "The sleeve " + sleeve.Name + " has been created.";
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                ViewBag.Message = "Please login to create a new sleeve";
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleeve sleeve= db.Sleeves.Find(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            return View(sleeve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sleeve sleeve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(sleeve).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(sleeve);
        }

        public ActionResult Delete(string id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Sleeve sleeve = db.Sleeves.Find(id);
            if (sleeve == null)
            {
                return HttpNotFound();
            }
            return View(sleeve);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Sleeve movie = db.Sleeves.Find(id);
                db.Sleeves.Remove(movie);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}