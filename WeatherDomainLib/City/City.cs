using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherLib;

namespace WeatherDomainLib.City
{
    /// <summary>
    /// Город
    /// </summary>
    public class City : ICity
    {
        /// <summary>
        /// Уникальный код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Координаты
        /// </summary>
        public ICoordinate Coord {get ;set;}
        /// <summary>
        /// Координаты города
        /// </summary>
        public class Coordinate : ICoordinate {
            /// <summary>
            /// Широта
            /// </summary>
            public decimal Latitude { get; set; }
            /// <summary>
            /// Долгота
            /// </summary>
            public decimal Longitude { get; set; }

        }

        public int CompareTo(ICity other_)
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
