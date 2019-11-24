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
using WeatherLib.YandexWeatherMap;
using WeatherLib.YandexWeatherMap.Classes;
using System.Net.Cache;

namespace WeatherLib.YandexWeatherMap
{
    /// <summary>
    /// Класс для работы с сервисом "YandexWeatherMap"(паттерн "Одиночка"(Singleton))
    /// </summary>
    public class YandexWeatherMap : IWeatherService
    {
        private YandexWeatherMap() { 
            
        }

        private static YandexWeatherMap _instance = null;
        public static YandexWeatherMap Get()
        {
            if (_instance == null)
                _instance = new YandexWeatherMap();
            return _instance;
        }

        private string _apiKey;// = "6751ae628280d64a208061753519757f";


        public IWeatherInfo GetWeather(decimal latitude_, decimal longitude_) {
            if (string.IsNullOrEmpty(_apiKey))
                throw new Exception("Отсутсвувет ключ работы с сервисом");

            var url = getYandexWeatherMapURL(latitude_, longitude_);
            var str = getResponseString(url);
            
            var wRes = deserialize(str);
            return new WeatherInfo(wRes);
        }


        public IWeatherInfo GetWeather(ICity city_)
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new Exception("Отсутсвувет ключ работы с сервисом");

            var url = getYandexWeatherMapURL(city_.Coord.Latitude, city_.Coord.Longitude);
            var str = getResponseString(url);

            var wRes = deserialize(str);
            return new WeatherInfo(wRes);
        }

        public void SetKey(string apiKey_) {
            _apiKey = apiKey_;
        }



        /// <summary>
        /// Получить url запроса погоды
        /// </summary>
        /// <param name="cityName_">Город, чью погоду мы хотим узнать</param>
        /// <param name="apiKey_">Ключ</param>
        /// <returns></returns>
        private string getYandexWeatherMapURL(
            decimal latitude_, decimal longitude_, string lang_= "ru_RU")
        {
            var url = $"https://api.weather.yandex.ru/v1/forecast?lat={latitude_.ToString()}&lon={longitude_.ToString()}";
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
            httpWebRequest.Headers.Add("X-Yandex-API-Key", _apiKey);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            System.Diagnostics.Debug.WriteLine($"Yandex Map: {httpWebResponse.IsFromCache}");

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
        private IYandexWeatherResponse deserialize(string responseStr_)
        {
            IYandexWeatherResponse wRes = JsonConvert.DeserializeObject<YandexWeatherResponse>(responseStr_);
            return wRes;
        }

    }
}
