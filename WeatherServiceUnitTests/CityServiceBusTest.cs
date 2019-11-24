using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WeatherLib;
using WeatherLib.OpenWeatherMap;
using WeatherLib.YandexWeatherMap;

using WeatherDomainLib.City;

using Moq;


namespace WeatherServiceUnitTests
{
    [TestClass]
    public class CityServiceBusTest
    {
        protected readonly ICityServicesBus _cityBus = CityServicesBus.Get();

        protected readonly Mock<ICity> _moqEburg = null;
        protected readonly Mock<ICity> _moqMadrid = null;

        public  CityServiceBusTest()
        {
            //Екатеринбург  
            var moqEburgCoord = new Mock<ICoordinate>();
            moqEburgCoord.Setup(crd => crd.Latitude).Returns(56.8519M);
            moqEburgCoord.Setup(crd => crd.Longitude).Returns(60.6122M);

            _moqEburg = new Mock<ICity>();
            _moqEburg.Setup(c => c.Id).Returns(1);
            _moqEburg.Setup(c => c.Name).Returns("Yekaterinburg");
            _moqEburg.Setup(c => c.Coord).Returns(moqEburgCoord.Object);

            //Мадрид
            var moqMadridCoord = new Mock<ICoordinate>();
            moqMadridCoord.Setup(crd => crd.Latitude).Returns(40.41M);
            moqMadridCoord.Setup(crd => crd.Longitude).Returns(-3.702M);

            _moqMadrid = new Mock<ICity>();
            _moqMadrid.Setup(c => c.Id).Returns(4);
            _moqMadrid.Setup(c => c.Name).Returns("Madrid");
            _moqMadrid.Setup(c => c.Coord).Returns(moqMadridCoord.Object);
        }
      


        [TestInitialize]
        public void Initialize()
        {
            _cityBus.AddCity(_moqEburg.Object);
            _cityBus.AddCity(_moqMadrid.Object);
        }

    
        [TestCleanup]
        public void Cleanup()
        {
            _cityBus.Clear();
        }

        [TestMethod]
        public void GetCities()
        {
            //act
            var serviceList = _cityBus.GetCities();

            //assert
            Assert.IsTrue(serviceList.Count == 2, "Количество сервисов не равно двум");
            Assert.IsTrue(serviceList.Exists(c => c.Id == _moqEburg.Object.Id), "В списке нет Екатеринбурга");
            Assert.IsTrue(serviceList.Exists(c => c.Id == _moqMadrid.Object.Id), "В списке нет Мадрида");
        }

        [TestMethod]
        public void GeCityById()
        {
            //act
            var eburg = _cityBus.GetCityById(1);
            var madrid = _cityBus.GetCityById(4);

            //assert
            Assert.AreEqual<int>(eburg.Id, 1, "(Е-бург): Сохранилось неправильное уникальный код города");
            Assert.AreEqual<string>(eburg.Name, "Yekaterinburg", "(Е-бург): Сохранилось неправильное название города");
            Assert.AreEqual<decimal>(eburg.Coord.Latitude, 56.8519M, "(Е-бург): Сохранилось неправильная широта города");
            Assert.AreEqual<decimal>(eburg.Coord.Longitude, 60.6122M, "(Е-бург): Сохранилось неправильная долгота города");

            //assert
            Assert.AreEqual<int>(madrid.Id, 4, "(Мадрид): Сохранилось неправильное уникальный код города");
            Assert.AreEqual<string>(madrid.Name, "Madrid", "(Мадрид): Сохранилось неправильное название города");
            Assert.AreEqual<decimal>(madrid.Coord.Latitude, 40.41M, "(Мадрид): Сохранилось неправильная широта города");
            Assert.AreEqual<decimal>(madrid.Coord.Longitude, -3.702M, "(Мадрид): Сохранилось неправильная долгота города");

            Assert.ThrowsException<Exception>(() => _cityBus.GetCityById(3), "Метод 'GetCityById' не вернул исключения");
        }

        [TestMethod]
        public void AddService()
        {
            //act
            Assert.ThrowsException<ArgumentException>(
                () => _cityBus.AddCity(_moqEburg.Object),
                "При добавлении города с уже существующим Id не возникло исключения");
            
        }

    }
}
