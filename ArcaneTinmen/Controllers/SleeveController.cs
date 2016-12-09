using System.Web;
using System.Web.Mvc;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using System.IO;
using System;
using System.Text;
using System.Data;

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
            return View();
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

        public ActionResult Edit(Sleeve sleeve)
        {
            return View();
        }
    }
}