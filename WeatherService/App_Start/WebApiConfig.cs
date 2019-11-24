using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WeatherService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config_)
        {
            config_.MapHttpAttributeRoutes();

            config_.Routes.MapHttpRoute(
                name: "DefaultApi",
                //routeTemplate: "api/{controller}/{action}"
                routeTemplate: "api/{controller}"
                //, defaults: new { id = RouteParameter.Optional }
            );


            //config_.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
        }
    }
}