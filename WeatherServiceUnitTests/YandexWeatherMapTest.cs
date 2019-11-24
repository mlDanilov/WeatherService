using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WeatherLib;
using WeatherLib.OpenWeatherMap;
using WeatherLib.YandexWeatherMap;

using WeatherDomainLib.Weather;

using Moq;

namespace WeatherServiceUnitTests
{
    [TestClass]
    public class YandexWeatherMapTest
    {

        private readonly YandexWeatherMap _yaService = null;

        private readonly Mock<ICity> _yekaterinburg = null;

        private readonly string _apiKey = "1149c371-2412-44ae-9b44-33d25dd35216";


        public YandexWeatherMapTest() {
            _yaService = YandexWeatherMap.Get();

            Mock<ICoordinate> yekatCoord = new Mock<ICoordinate>();
            yekatCoord.Setup(crd => crd.Latitude).Returns(56.8519M);
            yekatCoord.Setup(crd => crd.Longitude).Returns(60.6122M);

            _yekaterinburg = new Mock<ICity>();
            _yekaterinburg.Setup(c => c.Id).Returns(1);
            _yekaterinburg.Setup(c => c.Name).Returns("Yekaterinburg");
            _yekaterinburg.Setup(c => c.Coord).Returns(yekatCoord.Object);
        }

        /// <summary>
        /// При отсутсвии персонального ключа, должно возникать исключение
        /// </summary>
        [TestMethod]
        public void GetWeatherInfoWithoutKey()
        {
            //Arrange 
            _yaService.SetKey(null);

            //act


            //assert
            Assert.ThrowsException<Exception>(() => _yaService.GetWeather(_yekaterinburg.Object), "Сервис Yandex не выдал исключения, хотя персональный ключ равен null");
        }

        /// <summary>
        /// Проверка получения данных о погоде
        /// </summary>
        [TestMethod]
        public void GetWeatherInfoWithKey()
        {
            //Arrange 
            _yaService.SetKey(_apiKey);

            //act
            var wInfo = _yaService.GetWeather(_yekaterinburg.Object);

            //assert
            Assert.IsNotNull(wInfo, "Сервис погоды Yandex вернул пустую ссылку");
            Assert.IsTrue(
                wInfo.Humidity != 0 &&
                wInfo.Pressure != 0 &&
                wInfo.Pressure_mmH2O != 0 &&
                wInfo.Temp != 0, "Сервис погоды Yandex вернул некорректные данные");
        }

    }
}
