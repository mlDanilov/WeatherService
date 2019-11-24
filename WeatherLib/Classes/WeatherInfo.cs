using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherLib.YandexWeatherMap;
using WeatherLib.OpenWeatherMap;

namespace WeatherLib.Classes
{
    /// <summary>
    /// Информация о погоде с сервисов 
    /// </summary>
    class WeatherInfo : IWeatherInfo
    {
        public WeatherInfo(IYandexWeatherResponse yaResp_)
        {
            Temp = yaResp_.Fact.temp;
            Pressure = yaResp_.Fact.pressure_Pa;
            Pressure_mmH2O = yaResp_.Fact.pressure_mm;
            Humidity = yaResp_.Fact.humidity;
            Time = yaResp_.now_dt.ToLocalTime();
        }

        public WeatherInfo(IOpenWeatherResponse owResp_)
        {
            Temp = owResp_.Main.Temp;
            Pressure = owResp_.Main.Pressure;
            Pressure_mmH2O = owResp_.Main.Pressure_mmH2O;
            Humidity = owResp_.Main.Humidity;
            
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(owResp_.dt).ToLocalTime();
            Time = dtDateTime;
        }
        public DateTime Time { get; set; }
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
        public short Pressure_mmH2O { get; set; }
        /// <summary>
        /// Влажность, %
        /// </summary>
        public short Humidity { get; set; }
    }
}
