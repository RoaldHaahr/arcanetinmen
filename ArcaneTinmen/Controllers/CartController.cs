using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using System.Web.Mvc;
using ArcaneTinmen.ViewModels;

namespace ArcaneTinmen.Controllers
{
    public class CartController : Controller
    {
        private ArcaneTinmenContext db;

        public CartController()
        {
            db = new ArcaneTinmenContext();
        }

        public ViewResult Index(Cart cart, string returnurl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnurl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, string sleeveId, string returnUrl, int sleeveAmount = 1)
        {
            Sleeve sleeve = db.Sleeves.FirstOrDefault(s => s.SleeveId == sleeveId);

            if(sleeve != null)
            {
                cart.AddItem(sleeve, sleeveAmount);
            }

            return RedirectToAction("index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, string sleeveId, string returnUrl)
        {
            Sleeve sleeve = db.Sleeves.FirstOrDefault(s => s.SleeveId == sleeveId);
            if (sleeve != null)
            {
                cart.RemoveItem(sleeve);
            }
            return RedirectToAction("index", new { controller = returnUrl.Substring(1) });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                // order processing logic
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}
