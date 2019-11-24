using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.OpenWeatherMap
{
    /// <summary>
    /// Класс с информацией о погоде в городе
    /// </summary>
    public interface IOpenWeatherTempInfo
    {
        /// <summary>
        /// Температура, C
        /// </summary>
        float Temp { get; set; }
        /// <summary>
        /// Давление, Паскаль
        /// </summary>
        short Pressure { get; set; }

        /// <summary>
        /// Давление, мм рт ст
        /// </summary>
        short Pressure_mmH2O { get; }
        /// <summary>
        /// Влажность, %
        /// </summary>
        short Humidity { get; set; }
    }
}
