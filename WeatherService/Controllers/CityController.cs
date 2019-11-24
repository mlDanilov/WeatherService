using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WeatherDomainLib.City;
using WeatherLib;

namespace WeatherService.Controllers
{
    /// <summary>
    /// Контроллер для работы с городами
    /// </summary>
    public class CityController : ApiController
    {
        /// <summary>
        /// Получить доступный список городов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ICity> Get()
        {
            var cityList = CityServicesBus.Get().GetCities();
            return cityList;
        }
    }
}
