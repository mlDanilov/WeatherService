using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Newtonsoft.Json;
using WeatherLib;
using System.IO;
using WeatherLib.Classes;
using WeatherLib.OpenWeatherMap.Classes;
using System.Net.Cache;

namespace WeatherLib.OpenWeatherMap
{
    /// <summary>
    /// Класс для работы с сервисом "OpenWeatherMap"(паттерн "Одиночка"(Singleton))
    /// </summary>
    public class OpenWeatherMap : IWeatherService
    {
        private OpenWeatherMap() { 
        
        }

        private static OpenWeatherMap _instance = null;
        private string _apiKey;// = "6751ae628280d64a208061753519757f";

        /// <summary>
        /// Получить погоду города
        /// </summary>
        /// <param name="city_"></param>
        /// <returns></returns>
        public IWeatherInfo GetWeather(ICity city_)
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new Exception("Отсутсвувет ключ работы с сервисом");

            var url = getOpenWeatherMapURL(city_.Name);
            var str = getResponseString(url);
            var wRes = deserialize(str);
            return new WeatherInfo(wRes);
        }

        public void SetKey(string apiKey_) {
            _apiKey = apiKey_;
        }

        public static OpenWeatherMap Get()
        {
            if (_instance == null)
                _instance = new OpenWeatherMap();
            return _instance;
        }

        /// <summary>
        /// Получить url запроса погоды
        /// </summary>
        /// <param name="cityName_">Город, чью погоду мы хотим узнать</param>
        /// <param name="apiKey_">Ключ</param>
        /// <returns></returns>
        private string getOpenWeatherMapURL(string cityName_)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName_}&units=metric&appid={_apiKey}";
            //+ location_ + "&mode=xml&units=metric&APPID=" + APIKEY;

            return url;
        }
        /// <summary>
        /// Получить строку-ответ с погодного сервиса
        /// </summary>
        /// <param name="url_"></param>
        /// <returns></returns>
        private string getResponseString(string url_)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url_);
            var noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            httpWebRequest.CachePolicy = noCachePolicy;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            System.Diagnostics.Debug.WriteLine($"Open Weather Map: {httpWebResponse.IsFromCache}");
            string response;
            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            return response;
        }
        /// <summary>
        /// Десериализовать строку в экземпляр объекта с информацией по погоде
        /// </summary>
        /// <param name="responseStr_"></param>
        /// <returns></returns>
        private IOpenWeatherResponse deserialize(string responseStr_) {
            IOpenWeatherResponse wRes = JsonConvert.DeserializeObject<OpenWeatherWeatherResponse>(responseStr_);
            return wRes;
        }

    }
}
