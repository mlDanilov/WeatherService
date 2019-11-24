using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WeatherDomainLib;
using WeatherDomainLib.Weather;

namespace WeatherService.Controllers
{
    using WeatherService = WeatherDomainLib.Weather.WeatherService;
    /// <summary>
    /// Контроллер для работы с погодными сервисами
    /// </summary>
    public class WeatherServiceController : ApiController
    {

        [HttpGet]
        public List<WeatherService> Get()
        {
            var wServices = WeatherServicesBus.Get().GetServices();
            var wServList = wServices.Select(sv => new WeatherService(sv.Id, sv.Name)).ToList();
            return wServList;
        }
    }
}
