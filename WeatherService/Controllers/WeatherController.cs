using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherService.Models;

using WeatherDomainLib.Weather;
using WeatherDomainLib.City;
using WeatherLib;
//using System.Web.Mvc;

namespace WeatherService.Controllers
{
    /// <summary>
    /// Сервис получения данных о погоде по городу с разных сервисов
    /// </summary>
    
    public class WeatherController : ApiController
    {
   
        /// <summary>
        /// Получить информацию о погоде в городе из указанного сервиса
        /// </summary>
        /// <param name="cityId_">Уникальный код города</param>
        /// <param name="serviceId_">Уникальный код сервиса погоды</param>
        /// <returns></returns>
        [HttpGet]
        public IWeatherInfo Get([FromUri]int cityId_, [FromUri]int serviceId_)
        {
            var service = WeatherServicesBus.Get().GetWthrServiceItemById(serviceId_);
            var city = CityServicesBus.Get().GetCityById(cityId_);
            var weatherInfo = service.WeatherService.GetWeather(city);
            weatherInfo.Time = DateTime.Now;
            return weatherInfo;
        }

    }
}
