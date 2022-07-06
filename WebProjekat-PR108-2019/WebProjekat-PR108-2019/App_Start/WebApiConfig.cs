﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebProjekat_PR108_2019
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
                routeTemplate: "api/{controller}/{id}/{naziv}",
                defaults: new { id = RouteParameter.Optional, naziv = RouteParameter.Optional }
            );
        }
    }
}
