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
        public ActionResult Index()
        {
            using (ArcaneTinmenContext db = new ArcaneTinmenContext())
            {
                return View(db.Sleeves.ToList());
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            using (ArcaneTinmenContext db = new ArcaneTinmenContext())
            {
                var admn = db.Admins.Single(a => a.Username == admin.Username && a.Password == admin.Password);
                if (admn != null)
                {
                    Session["AdminId"] = admin.AdminId.ToString();
                    Session["AdminUserName"] = admn.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
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
    }
}