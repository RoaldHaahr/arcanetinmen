using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;
using System.Web.Mvc;
using ArcaneTinmen.ViewModels;
using System.Data.Entity;

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
        [ValidateAntiForgeryToken]
        public ViewResult Checkout(Cart cart, [Bind(Include = "FirstName,Lastname,Address,Zip,City,Country,Email")] ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    Firstname = shippingDetails.Firstname,
                    Lastname = shippingDetails.Lastname,
                    Address = shippingDetails.Address,
                    Zip = shippingDetails.Zip,
                    Email = shippingDetails.Email
                };

                if (db.Customers.Any(s => s.Firstname == shippingDetails.Firstname && s.Lastname == shippingDetails.Lastname && s.Email == shippingDetails.Email))
                {
                    customer = db.Customers.Where(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email).First();
                    customer.Address = shippingDetails.Address;
                    customer.Zip = shippingDetails.Zip;
                    db.Entry(customer).State = EntityState.Modified;
                }
                Order order = new Order(DateTime.Now, customer);

                foreach(CartLine cartLine in cart.Lines)
                {
                    OrderLine orderLine = new OrderLine(cartLine.Sleeve, cartLine.Quantity);
                    orderLine.SleeveId = cartLine.Sleeve.SleeveId;
                    orderLine.Sleeve = null;
                    order.OrderLines.Add(orderLine);
                }
                db.Orders.Add(order);
                db.SaveChanges();
                // order processing logic
                /*     db.ShippingDetails.Add(new ShippingDetails
                     {
                         Firstname = shippingDetails.Firstname;
                     }); */

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
