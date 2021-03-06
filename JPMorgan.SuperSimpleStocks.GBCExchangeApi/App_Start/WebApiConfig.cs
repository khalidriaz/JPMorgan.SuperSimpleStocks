﻿using System.Net.Http.Headers;
using System.Web.Http;

namespace JPMorgan.SuperSimpleStocks.GBCExchangeApi
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
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //IOC using Unity Framework. Registering and Resolving dependencies.
            UnityConfig.RegisterComponents();
            
            //Setting JSON to return as default.
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
