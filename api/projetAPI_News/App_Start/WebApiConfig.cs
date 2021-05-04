using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace projetAPI_News
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi1",
                routeTemplate: "api/Test/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            Console.WriteLine("jesaiscpaspropre");
            //Console.OpenStandardOutput();
            System.Diagnostics.Debug.WriteLine("test");
            
        }
    }
}
