using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.EnableCors();
            
            config.MapHttpAttributeRoutes();
         
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}/{id2}/{id3}/{name}/{name2}/{name3}",
                defaults: new { id = RouteParameter.Optional, id2 = RouteParameter.Optional, id3 = RouteParameter.Optional, name = RouteParameter.Optional ,name2= RouteParameter.Optional , name3 = RouteParameter.Optional }
            );
        }
    }
}
