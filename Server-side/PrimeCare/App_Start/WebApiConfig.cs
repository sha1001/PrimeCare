// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file= WebApiConfig.cs company="Perimatics Inc.">
// //   Copyright (C) 2018 Perimatics Inc. All rights reserved.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;

namespace PrimeCare
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}