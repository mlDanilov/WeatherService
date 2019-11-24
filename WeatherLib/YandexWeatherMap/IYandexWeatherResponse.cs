using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib.YandexWeatherMap
{
    interface IYandexWeatherResponse
    {
        DateTime now_dt { get; set; }

        IYandexTemperatureInfo Fact { get; set; }

    }
}
