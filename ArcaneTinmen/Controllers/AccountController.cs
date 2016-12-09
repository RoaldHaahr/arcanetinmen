using System.Linq;
using System.Web.Mvc;
using ArcaneTinmen.Models;
using ArcaneTinmen.DAL;

namespace ArcaneTinmen.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (ArcaneTinmenContext db = new ArcaneTinmenContext())
            {
                return View(db.Customers.ToList());
            }
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer account)
        {
            if (ModelState.IsValid)
            {
                using (ArcaneTinmenContext db = new ArcaneTinmenContext())
                {
                    db.Customers.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + "You have succesfully registered";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer account)
        {
            using (ArcaneTinmenContext db = new ArcaneTinmenContext())
            {
                var cust = db.Customers.Single(c => c.Email == account.Email && c.Password == account.Password);
                if (cust != null)
                {
                    Session["CustomerId"] = account.CustomerId.ToString();
                    Session["CustomerName"] = cust.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }         
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong.");
                }
        }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["CustomerId"] != null)
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