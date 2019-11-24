using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    /// <summary>
    /// Сервис погоды
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Возвращает данные о погоде
        /// </summary>
        /// <param name="city_"></param>
        /// <returns></returns>
        IWeatherInfo GetWeather(ICity city_);

        /// <summary>
        /// Установить персональный ключ активации
        /// </summary>
        /// <param name="apiKey_"></param>
        void SetKey(string apiKey_);

    }
}
