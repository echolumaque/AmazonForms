using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AmazonRest.Helpers;
using Newtonsoft.Json.Serialization;

namespace AmazonRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new CompressAttribute());
            config.Filters.Add(new ForceHTTPSAttribute());
        }
    }
}