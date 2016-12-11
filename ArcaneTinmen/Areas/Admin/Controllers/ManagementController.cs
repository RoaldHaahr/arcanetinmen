using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArcaneTinmen.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
        private ArcaneTinmenContext db;

        public ManagementController()
        {
            db = new ArcaneTinmenContext();
        }

        // GET: Admin/Management
        public ActionResult Index()
        {
            if (Session["AdminId"] == null) return RedirectToAction("Login");

            return RedirectToAction("Index", "Sleeves");
        }

        public ActionResult Login()
        {
            if (Session["AdminId"] != null) return RedirectToAction("Index", "Sleeves");

            return View();
        }

        [HttpPost]
        public ActionResult Login(Account admin)
        {
            if (Session["AdminId"] != null) return RedirectToAction("Index", "Sleeves");

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
    }
}