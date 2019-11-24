using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherLib;

namespace WeatherDomainLib.Weather
{
    /// <summary>
    /// Позиция "Сервис погоды" доступная пользователю
    /// </summary>
    internal class WeatherServiceItem : IWeatherServiceItem
    {
        public WeatherServiceItem(int id_, string name_, IWeatherService weatherService_)
        {
            Id = id_;
            Name = name_;
            WeatherService = weatherService_;
        }
        /// <summary>
        /// Ключ
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Сервис погоды
        /// </summary>
        public IWeatherService WeatherService { get; private set; }

        public int CompareTo(IWeatherServiceItem other_)
        {
            if (this.Id == other_.Id)
                return 0;
            else if (this.Id > other_.Id)
                return 1;
            else 
                return -1;
        }
    }
}
