using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcaneTinmen.Models;
using ArcaneTinmen.DAL;

namespace ArcaneTinmen.Controllers
{
    public class AdminController : Controller
    {

        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] != null)
            {
                    return View(db.Sleeves.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
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
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public PartialViewResult Sleeves()
        {
                List<Sleeve> model = db.Sleeves.ToList();
                return PartialView("Sleeves/Sleeves", model);
        }
    }
}