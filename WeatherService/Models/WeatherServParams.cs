using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherLib;

namespace WeatherService.Models
{
    /// <summary>
    /// Параметры, передаваемые в контроллер погодного сервиса
    /// </summary>
    public class WeatherServParams
    {
        /// <summary>
        /// Уникальный код города
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Ключ сервиса погоды
        /// </summary>
        public int ServiceId { get; set; }
    }
}