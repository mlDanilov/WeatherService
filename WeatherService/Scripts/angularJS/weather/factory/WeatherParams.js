'use strict';
weatherApp.factory('WeatherParams', function ($http) {


    let _city = null;
    let _weatherService = null;

    //Получить параметры запроса для получения информации о погоде
    let getWeatherServParams = function () {
        if ((_city == null) || (_city == undefined))
            return null;

        if ((_weatherService == null) || (_weatherService == undefined))
            return null;

        let params = {
            CityId: _city.Id,
            ServiceId: _weatherService.Id
        }
        return params;
    };

    return {

        //Установить текущий город
        setCity: function (city_) {
            _city = city_;
        },
        //Установить сервис погоды
        setWeatherService: function (weatherService_) {
            _weatherService = weatherService_;
        },
        //Получить ключ от хранилища
        getStorageKey: function () {
            if (_city == null || _weatherService == null)
                return null;
            return _city.Id + "_" + _weatherService.Id;
        },
        //Получить последние пользовательские параметры
        getLastUserParams: function () {
            if (_city == null || _weatherService == null)
                return null;
            return {
                CityId: _city.Id,
                WeatherId: _weatherService.Id
            }
        },
        //Получить промис "инфморация о погоде"
        getWeatherInfo: function () {
            let args = getWeatherServParams();
            if (args == null)
                return null;

            //return $http({
            //    method: 'POST',
            //    url: "/api/Weather/",
            //    data: { 'CityId': args.CityId, 'ServiceId': args.ServiceId }
                
            //})
            return $http({
                method: 'GET',
                url: "/api/Weather/",
                params: { 'cityId_': args.CityId, 'serviceId_': args.ServiceId }

            })
        }
        

    }
});