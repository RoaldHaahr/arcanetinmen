using ArcaneTinmen.DAL;
using ArcaneTinmen.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ArcaneTinmen.Controllers
{
    public class HomeController : Controller
    {
        private ArcaneTinmenContext db;

        // GET: Home
        public ActionResult Index()
        {
            db = new ArcaneTinmenContext();
            SleeveListViewModel model = new SleeveListViewModel
            {
                Sleeves = db.Sleeves.ToList()
            };
            return View(model);
        }
    }
}