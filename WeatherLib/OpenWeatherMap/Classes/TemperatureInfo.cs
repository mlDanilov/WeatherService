using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.OpenWeatherMap.Classes
{
    /// <summary>
    /// Класс с информацией о погоде в городе
    /// </summary>
    class OpenWeatherTemperatureInfo : IOpenWeatherTempInfo
    {
        /// <summary>
        /// Температура, C
        /// </summary>
        public float Temp { get; set; }
        /// <summary>
        /// Давление, Паскаль
        /// </summary>
        public short Pressure { get; set; }
        /// <summary>
        /// Давление, мм рт ст
        /// </summary>
        public short Pressure_mmH2O
        { 
            get {
                return (short)(Pressure / 1.33322f);
            }
        }
        /// <summary>
        /// Влажность, %
        /// </summary>
        public short Humidity { get; set; }
    }
}
