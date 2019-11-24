using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib
{
    /// <summary>
    /// Город
    /// </summary>
    public interface ICity :IComparable<ICity>
    {
        /// <summary>
        /// Уникальный код
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Координаты
        /// </summary>
        ICoordinate Coord { get; set; }
    }

    /// <summary>
    /// Координаты города
    /// </summary>
    public interface ICoordinate
    {
        /// <summary>
        /// Широта 
        /// </summary>
        decimal Latitude { get; set; }
        /// <summary>
        /// Долгота 
        /// </summary>
        decimal Longitude { get; set; }
    }


}
