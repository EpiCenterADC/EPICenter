using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace EPiCenterBaseProject.Business.AppStart
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
            "QuickPollBlock",
            "QuickPollBlock/Index",
            new { controller = "QuickPollBlock", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "PageNotFound", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}