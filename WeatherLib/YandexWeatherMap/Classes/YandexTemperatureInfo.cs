using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.YandexWeatherMap.Classes
{
    /// <summary>
    /// Информация о погоде с сервиса Яндекс.Погода
    /// (Класс создан для десериализации)
    /// </summary>
    class YandexTemperatureInfo : IYandexTemperatureInfo
    {
        
        /// <summary>
        /// Температура, C
        /// </summary>
        public float temp { get; set; }
        /// <summary>
        /// Давление, Паскаль
        /// </summary>
        public short pressure_mm { get; set; }
        /// <summary>
        /// Давление, мм рт ст
        /// </summary>
        public short pressure_Pa { get; set; }
        /// <summary>
        /// Влажность, %
        /// </summary>
        public short humidity { get; set; }
    }
}
