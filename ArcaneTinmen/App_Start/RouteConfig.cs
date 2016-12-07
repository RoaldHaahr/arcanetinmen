using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArcaneTinmen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: null,
              url: "{controller}/Page{page}",
              defaults: new { controller = "Catalogue", action = "Index", category = (string)null },
              constraints: new { page = @"\d+" }
          );

            routes.MapRoute(
             name: null,
             url: "{controller}/{category}/Page{page}",
             defaults: new { controller = "Catalogue", action = "Index" },
             constraints: new { page = @"\d+" }
         );

        }
    }
}
