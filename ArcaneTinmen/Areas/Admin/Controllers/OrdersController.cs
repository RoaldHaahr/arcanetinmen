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
    public class OrdersController : Controller
    {
        private ArcaneTinmenContext db = new ArcaneTinmenContext();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.OrderLines);
            return View(orders.ToList());
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
