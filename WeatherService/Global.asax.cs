using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using WeatherDomainLib.Weather;
using WeatherLib.OpenWeatherMap;
using WeatherLib.YandexWeatherMap;
using WeatherLib;
using WeatherDomainLib.City;

namespace WeatherService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            setWeatherServices();
            setCities();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        /// ”становить сервисы погоды, доступные пользователю
        /// </summary>
        protected void setWeatherServices()
        {
            var opServ = OpenWeatherMap.Get();
            opServ.SetKey("6751ae628280d64a208061753519757f");
            WeatherServicesBus.Get().AddService(1, "Open Weather Map", opServ);

            var yndxServ = YandexWeatherMap.Get();
            yndxServ.SetKey("1149c371-2412-44ae-9b44-33d25dd35216");
            WeatherServicesBus.Get().AddService(2, "Yandex Weather Map", yndxServ);
        }

        /// <summary>
        /// ”становить города, доступные пользователю
        /// </summary>
        protected void setCities() {
            
            List<ICity> cityList = new List<ICity>();
            var yekaterinburg = new City()
            {
                Id = 1,
                Name = "Yekaterinburg",
                Coord = new City.Coordinate
                {
                    Latitude = 56.8519M,
                    Longitude = 60.6122M
                }
            };
            var madrid = new City()
            {
                Id = 4,
                Name = "Madrid",
                Coord = new City.Coordinate
                {
                    Latitude = 40.41M,
                    Longitude = -3.702M
                }
            };
            var vladivostok = new City()
            {
                Id = 5,
                Name = "Vladivostok",
                Coord = new City.Coordinate
                {
                    Latitude = 43.1056M,
                    Longitude = 131.8735M
                }
            };

            CityServicesBus.Get().AddCity(yekaterinburg);
            CityServicesBus.Get().AddCity(madrid);
            CityServicesBus.Get().AddCity(vladivostok);
        }
    }
}
