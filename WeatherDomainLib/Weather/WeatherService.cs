using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDomainLib.Weather
{
    /// <summary>
    /// Класс "Сервис погоды"
    /// </summary>
    public class WeatherService
    {
        public WeatherService(int Id_, string Name_) {
            Id = Id_;
            Name = Name_;
        }
        /// <summary>
        /// Уникальный код
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; private set; }
    }
}
