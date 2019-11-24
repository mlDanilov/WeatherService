using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WeatherLib;

namespace WeatherDomainLib.City
{
    /// <summary>
    /// Шина с доступными пользователю городами
    /// </summary>
    public interface ICityServicesBus
    {
        /// <summary>
        /// Добавить город в доступные для пользователя
        /// </summary>
        /// <param name="id_"></param>
        /// <param name="service_"></param>
        void AddCity(ICity city_);
        /// <summary>
        /// Получить город по уникальному ключу
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        ICity GetCityById(int id_);
        /// <summary>
        /// Получить список доступных пользователю городов
        /// </summary>
        /// <returns></returns>
        List<ICity> GetCities();

        void Clear();

    }

}