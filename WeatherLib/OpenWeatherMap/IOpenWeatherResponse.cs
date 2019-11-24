using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.OpenWeatherMap
{

    /// <summary>
    /// Ответ с погодного сервиса OpenWeather
    /// </summary>
    public interface IOpenWeatherResponse
    {
        /// <summary>
        /// Информация о погоде
        /// </summary>
        IOpenWeatherTempInfo Main { get; set; }

        string Name { get; set; }

        int dt { get; set; }
    }
}
