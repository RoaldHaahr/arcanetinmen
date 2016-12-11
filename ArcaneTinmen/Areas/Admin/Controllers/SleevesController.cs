using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;

namespace ArcaneTinmen.Areas.Admin.Controllers
{
    public class SleevesController : Controller
    {
        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        // GET: Admin/Sleeves
        public ActionResult Index()
        {
            return View(db.Sleeves.ToList());
        }

        // GET: Admin/Sleeves/Details/5
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

        // GET: Admin/Sleeves/List
        public ActionResult List()
        {
            return View(db.Sleeves.ToList());
        }

        // GET: Admin/Sleeves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sleeves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SleeveId,Name,Description,Height,Width,SalePrice,StockAmount,CardImageFileName,BadgeImageFileName")] Sleeve sleeve)
        {
            if (ModelState.IsValid)
            {
                db.Sleeves.Add(sleeve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sleeve);
        }

        // GET: Admin/Sleeves/Edit/5
        public ActionResult Edit(string id)
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

        // POST: Admin/Sleeves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SleeveId,Name,Description,Height,Width,SalePrice,StockAmount,CardImageFileName,BadgeImageFileName")] Sleeve sleeve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sleeve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sleeve);
        }

        // GET: Admin/Sleeves/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/Sleeves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sleeve sleeve = db.Sleeves.Find(id);
            db.Sleeves.Remove(sleeve);
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
