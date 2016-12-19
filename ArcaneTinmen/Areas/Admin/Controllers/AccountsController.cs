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
    public class AccountsController : Controller
    {
        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        // GET: Admin/Accounts
        public ActionResult Index()
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            return View(db.Accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,Username,Password,Email")] Account account)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,Username,Password,Email")] Account account)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");

            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            if (Session["AdminId"] != null) return RedirectToAction("Index");

            return View();
        }

        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(Account admin)
        {
            if (Session["AdminId"] != null) return RedirectToAction("Index");

            var admn = db.Accounts.Single(a => a.Username == admin.Username && a.Password == admin.Password);
            if (admn != null)
            {
                Session["AdminId"] = admin.AccountId.ToString();
                Session["AdminUserName"] = admn.Username.ToString();
                return RedirectToAction("Index", "Sleeves");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
            }

            return View();
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
