using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WeatherLib;

namespace WeatherDomainLib.City
{
    /// <summary>
    /// Шина с доступными пользователю городами
    /// в которые можно добавлять города
    /// </summary>
    public class CityServicesBus : ICityServicesBus
    {
        private CityServicesBus()
        {

        }

        public static ICityServicesBus Get() {

            if (_instance == null)
                _instance = new CityServicesBus();
            return _instance;
        }
        private static ICityServicesBus _instance = new CityServicesBus();
        /// <summary>
        /// SortedSet - значения должны быть уникальными
        /// </summary>
        private readonly List<ICity> _collection = new List<ICity>();




        /// <summary>
        /// Добавить город в доступные для пользователя
        /// </summary>
        /// <param name="id_"></param>
        /// <param name="city_"></param>
        public void AddCity(ICity city_)
        {
            if (_collection.Exists(c => c.Id == city_.Id))
                throw new ArgumentException($"В шине городов уже есть город с кодом {city_.Id}");
            _collection.Add(city_);
        }
        /// <summary>
        /// Получить город по ключу
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        public ICity GetCityById(int id_)
        {
            var res = _collection.FirstOrDefault(srv => srv.Id == id_);
            if (res == null)
                throw new Exception($"В шине городов отсутствует города с кодом {id_}");
            return res;
        }
        /// <summary>
        /// Получить все доступные пользователю города
        /// </summary>
        /// <returns></returns>
        public List<ICity> GetCities()
        {
            return _collection.ToList();
        }

        public void Clear()
        {
            _collection.Clear();
        }

    }

    
}