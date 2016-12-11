using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using System.Data.Entity;
using ArcaneTinmen.DAL;
using ArcaneTinmen.Models;

namespace ArcaneTinmen.Controllers
{
    public class CustomerController : Controller
    {

        private ArcaneTinmenContext db;

        public CustomerController()
        {
            db = new ArcaneTinmenContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
           

            return View();

        }
    }
}