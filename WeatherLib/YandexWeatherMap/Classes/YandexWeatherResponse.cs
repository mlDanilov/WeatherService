using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.YandexWeatherMap.Classes
{
    /// <summary>
    /// Ответ о погоде с сервиса "Яндекс.Погода"
    /// </summary>
    class YandexWeatherResponse : IYandexWeatherResponse
    {
        /// <summary>
        /// Текущая дата
        /// </summary>
        public DateTime now_dt { get; set ; }
        /// <summary>
        /// Информация о погоде
        /// </summary>
        public IYandexTemperatureInfo Fact { get; set; } = new YandexTemperatureInfo();
    }
}
