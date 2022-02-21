using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "SaveOrder",
            //    "SaveOrder/{UniqueIndentifier}",
            //    new { controller = "Home", action = "SaveOrder", UniqueIndentifier = "" }
            //    );

            routes.MapRoute(
                "GetYourOrder",
                "GetYourOrder/{addOrDelete}/{menuId}/{collOrDeli}/{UniqueIndentifier}",
                new { controller = "Home", action = "GetYourOrder", addOrDelete = "", menuId = 0, collOrDeli = "", UniqueIndentifier = "" }
                );

            routes.MapRoute(
                "Home",
                "Home/Index",
                new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
