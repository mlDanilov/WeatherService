using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.OpenWeatherMap.Classes
{
    class OpenWeatherWeatherResponse : IOpenWeatherResponse
    {
        public IOpenWeatherTempInfo Main { get; set; } = new OpenWeatherTemperatureInfo();

        public string Name { get; set; }

        public int dt { get; set; }
    }
}
