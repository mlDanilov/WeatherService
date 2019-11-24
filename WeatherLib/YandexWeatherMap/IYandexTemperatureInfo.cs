using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.YandexWeatherMap
{
    /// <summary>
    /// Информация о погоде с сервиса Яндекс.Погода
    /// (Интерфейс создан для десериализации)
    /// </summary>
    interface IYandexTemperatureInfo
    {
        /// <summary>
        /// Температура, C
        /// </summary>
        float temp { get; set; }
        /// <summary>
        /// Давление, Паскаль
        /// </summary>
        short pressure_mm { get; set; }
        /// <summary>
        /// Давление, мм рт ст
        /// </summary>
        short pressure_Pa { get; set; }
        /// <summary>
        /// Влажность, %
        /// </summary>
        short humidity { get; set; }
    }
}
