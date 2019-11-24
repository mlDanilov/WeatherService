using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WeatherLib;
using WeatherDomainLib.Weather;

namespace WeatherDomainLib.Weather
{
    /// <summary>
    /// Шина с сервисами погоды
    /// </summary>
    public class WeatherServicesBus : IWeatherServicesBus
    {
        private WeatherServicesBus()
        {

        }

        public static IWeatherServicesBus Get() {

            if (_instance == null)
                _instance = new WeatherServicesBus();
            return _instance;
        }
        private static IWeatherServicesBus _instance = new WeatherServicesBus();
        /// <summary>
        /// SortedSet - значения должны быть уникальными
        /// </summary>
        //private readonly SortedSet<IWeatherServiceItem> _collection = new SortedSet<IWeatherServiceItem>();
        //private readonly HashSet<IWeatherServiceItem> _collection = new HashSet<IWeatherServiceItem>();
        private readonly Dictionary<int ,IWeatherServiceItem> _collection = new Dictionary<int, IWeatherServiceItem>();




        /// <summary>
        /// Добавить сервис в доступные для пользователя
        /// </summary>
        /// <param name="id_"></param>
        /// <param name="service_"></param>
        public void AddService(int id_, string name_, IWeatherService service_)
        {
            var wthrService = new WeatherServiceItem(id_, name_, service_);
            _collection.Add(id_,wthrService);
        }
        /// <summary>
        /// Получить сервис по ключу
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public IWeatherServiceItem GetWthrServiceItemById(int id_)
        {
            if (!_collection.ContainsKey(id_))
                throw new Exception($"Сервис погоды с кодом {id_} отсутствует в шине сервисов");

            return _collection[id_];
        }
        /// <summary>
        /// Получить все сервисы с ключами
        /// </summary>
        /// <returns></returns>
        public List<IWeatherServiceItem> GetServices()
        {
            return _collection.Values.ToList();
        }

        public void Clear() {
            _collection.Clear();
        }

    }

    
}