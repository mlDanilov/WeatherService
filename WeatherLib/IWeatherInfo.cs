using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    /// <summary>
    /// Информация о погоде
    /// </summary>
    public interface IWeatherInfo
    {
        /// <summary>
        /// Температура, C
        /// </summary>
        float Temp { get; }
        /// <summary>
        /// Давление, Паскаль
        /// </summary>
        short Pressure { get; }

        /// <summary>
        /// Давление, мм рт ст
        /// </summary>
        short Pressure_mmH2O { get; }
        /// <summary>
        /// Влажность, %
        /// </summary>
        short Humidity { get; }

        DateTime Time { get; set; }

    }
}
