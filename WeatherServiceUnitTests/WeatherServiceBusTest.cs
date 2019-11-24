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
    public class WeatherServiceBusTest
    {
        protected readonly IWeatherServicesBus _wthrBus = WeatherServicesBus.Get();
        protected readonly Mock<IWeatherService> _moqYaService = new Mock<IWeatherService>();
        protected readonly Mock<IWeatherService> _moqOpWtMapService = new Mock<IWeatherService>();

        [TestInitialize]
        public void Initialize()
        {
            _wthrBus.AddService(1, "Yandex Open Map", _moqYaService.Object);
            _wthrBus.AddService(2, "Open Weather Map", _moqOpWtMapService.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _wthrBus.Clear();
        }

        [TestMethod]
        public void GetServices()
        {
            //act
            var serviceList = _wthrBus.GetServices();

            //assert
            Assert.IsTrue(serviceList.Count == 2, "Количество сервисов не равно двум");
            Assert.IsTrue(serviceList[0].WeatherService == _moqYaService.Object, "Первый сервис не является Yandex Open Map");
            Assert.IsTrue(serviceList[1].WeatherService == _moqOpWtMapService.Object, "Второй сервис не является Open Weather Map");
        }

        [TestMethod]
        public void GetWthrServiceItemById()
        {
            //act
            var yaService = _wthrBus.GetWthrServiceItemById(1);
            var opWthService = _wthrBus.GetWthrServiceItemById(2);

            //assert
            Assert.AreEqual<int>(yaService.Id, 1, "(Yandex Map): Сохранилось неправильное уникальный код сервиса");
            Assert.AreEqual<string>(yaService.Name, "Yandex Open Map", "(Yandex Map): Сохранилось неправильное название сервиса");
            Assert.AreSame(yaService.WeatherService, _moqYaService.Object, "(Yandex Map): Неправильная ссылка на объект в IWeatherServiceItem");

            Assert.AreEqual<int>(opWthService.Id, 2, "(Open Weather Map): Сохранилось неправильное уникальный код сервиса");
            Assert.AreEqual<string>(opWthService.Name, "Open Weather Map", "(Open Weather Map): Сохранилось неправильное название сервиса");
            Assert.AreSame(opWthService.WeatherService, _moqOpWtMapService.Object, "(Open Weather Map): Неправильная ссылка на объект в IWeatherServiceItem");

            Assert.ThrowsException<Exception>(() => _wthrBus.GetWthrServiceItemById(3), "Метод 'GetWthrServiceItemById' не вернул исключения");
        }

        [TestMethod]
        public void AddService()
        {
            //act
            Assert.ThrowsException<ArgumentException>(
                () => _wthrBus.AddService(1, "Wrong service with same Id ", _moqYaService.Object),
                "При добавлении сервиса погоды с уже существующим Id не возникло исключения");
            
        }

    }
}
