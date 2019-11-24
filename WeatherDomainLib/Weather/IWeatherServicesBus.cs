using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WeatherLib;

namespace WeatherDomainLib.Weather
{
    /// <summary>
    /// Шина с сервисами погоды
    /// </summary>
    public interface IWeatherServicesBus
    {
        /// <summary>
        /// Добавить сервис в доступные для пользователя
        /// </summary>
        /// <param name="id_"></param>
        /// <param name="service_"></param>
        void AddService(int id_, string Name_, IWeatherService service_);
        /// <summary>
        /// Получить сервис по ключу
        /// </summary>
        /// <param name="id_"></param>
        /// <returns></returns>
        IWeatherServiceItem GetWthrServiceItemById(int id_);
        /// <summary>
        /// Получить все сервисы с ключами
        /// </summary>
        /// <returns></returns>
        List<IWeatherServiceItem> GetServices();

        void Clear();

    }

    /// <summary>
    /// Позиция "Сервис погоды" доступная пользователю
    /// </summary>
    public interface IWeatherServiceItem : IComparable<IWeatherServiceItem>
    {
        /// <summary>
        /// Ключ
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Название
        /// </summary>
        string Name { get;  }
        /// <summary>
        /// Сервис погоды
        /// </summary>
        IWeatherService WeatherService { get; }
    }
}