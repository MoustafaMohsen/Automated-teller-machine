using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//handeled by totaly different rout engine that's why 
            //it's ignored,
            //the * means we want to treat it as a catchall (match everything evene / or = or any symbol) 
            //Mycode
            routes.MapRoute(
                name: "Serial number",
                url: "serial/{letterCase}",

                defaults: 
                new { controller = "Home", action = "serial",
                    letterCase ="Upper" }
            );

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
