using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatientPortal.CMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PatientPortal.CMS.Controllers" }
            );
            routes.MapRoute(
                name: "404-NotFound",
                url: "NotFound",
                defaults: new { controller = "HttpErrors", action = "NotFound" }
            );

            routes.MapRoute(
                name: "500-Error",
                url: "Error",
                defaults: new { controller = "HttpErrors", action = "Error" }
            );
            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "HttpErrors", action = "NotFound" }
            );
        }
    }
}
