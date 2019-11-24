'use strict'
var weatherApp = angular.module('weatherApp');
weatherApp.controller("weatherController", function (
    $scope, $cookies, $window, $interval, UserStorage, Cities, WeatherParams, WeatherService) {
   
    $scope.weatherInfo;

  

    //Получить информацию о погоде с погодных сервисов
    $scope.getWeatherInfo = function () {
        let params = WeatherParams.getWeatherServParams();
        return params;
    }

    //Города
    $scope.Cities = {
        SelectedItem : null,
        Items : []
    };

    //Сервисы
    $scope.WeatherServices = {
        SelectedItem: null,
        Items: []
    };

    //Текущий выбранный город изменился
    $scope.cityChanged = function () {
        //console.log("current city=");
        //console.log($scope.Cities.SelectedItem);
        WeatherParams.setCity($scope.Cities.SelectedItem);
        //let request = WeatherParams.getWeatherInfo();
        //if (request == null) return;

        //request.then(
        //    function successCallback(response) {
        //        console.log('cityChanged -> getWeatherInfo успех');

        //    },
        //    function errorCallback(response) {
        //        console.log('cityChanged -> getWeatherInfo ошибка');
        //    }

        //);

    }

    //Текущий погодный сервис изменился
    $scope.weatherServiceChanged = function () {
        //console.log("current WeatherService=");
        //console.log($scope.WeatherServices.SelectedItem);
        WeatherParams.setWeatherService($scope.WeatherServices.SelectedItem);
        //let request = WeatherParams.getWeatherInfo();
        //if (request == null) return;

        //request.then(
        //    function successCallback(response) {
        //        console.log('weatherServiceChanged -> getWeatherInfo успех');
        //    },
        //    function errorCallback(response) {
        //        console.log('weatherServiceChanged -> getWeatherInfo ошибка');
        //    }

        //);
    }

    //загрузить доступные города
    Cities.getAll().then(
        function successCallback(response) {

            let obj = response.data;
            $scope.Cities.Items = obj;
            console.log('Cities.getAll() успех');
           
        },
        function errorCallback(response) {
            console.log('Cities.getAll() ошибка');
        }
    );

    //загрузить доступные погодные сервисы
    WeatherService.getAll().then(
        function successCallback(response) {
            let obj = response.data;
            $scope.WeatherServices.Items = obj;
            console.log('WeatherServices.getAll() успех');
        },
        function errorCallback(response) {
            console.log('WeatherServices.getAll() ошибка');
        }
    );
    //Обработчик события,
    //Срабатывает, если изменился либо город, либо погодный сервис
    $scope.UserParamsChangedHandler = function () {
        console.log('$watch: UserParamsChangedHandler');
        //Устанавливаем в куки последние пользовательские данные
        $scope.setUserDataToStorage();    
        //Смотрим данные о погоде из куки 
        //или из сервисов, в зависимости от условий
        $scope.loadWeatherInfo();
    }

    //Устанавливаем в куки последние пользовательские данные
    $scope.setUserDataToStorage = function () {
        let lastUserData = WeatherParams.getLastUserParams();
        if (lastUserData != null) {
            //$cookies.putObject("lastUserData", lastUserData);
            UserStorage.putObject("lastUserData", lastUserData);
        }
    }

    //Загрузить последние пользовательские данные из хранилища
    $scope.loadFromStorageLastUserData = function()
    {
        if (($scope.Cities.Items.length == 0) ||
            ($scope.WeatherServices.Items.length == 0))
            return;

        //let lastUserData = $cookies.getObject("lastUserData");
        let lastUserData = UserStorage.getObject("lastUserData");

        //Если в куки есть пользовательские данные, 
        //устанавливаем их
        if (lastUserData != null) {
            let city = $scope.Cities.Items.find(c => c.Id == lastUserData.CityId);
            let wServ = $scope.WeatherServices.Items.find(srv => srv.Id == lastUserData.WeatherId);

            //Установить последние пользовательские данные
            //Сначала, как текущие параметра
            WeatherParams.setCity(city);
            WeatherParams.setWeatherService(wServ);
            //Теперь в интерфейс
            $scope.Cities.SelectedItem = city;
            $scope.WeatherServices.SelectedItem = wServ;
        }
        //Подписать установить обработчик события "текущий город изменился"
        $scope.$watch('Cities.SelectedItem', $scope.UserParamsChangedHandler)
        //Подписать установить обработчик события "текущий сервис погоды"
        $scope.$watch('WeatherServices.SelectedItem', $scope.UserParamsChangedHandler)
    }

    //Как только загрузятся все города и сервисы,
    //можно начать загружать последние пользовательские данные
    $scope.$watch('Cities.Items', $scope.loadFromStorageLastUserData);
    $scope.$watch('WeatherServices.Items', $scope.loadFromStorageLastUserData);
    //Загрузить пользовательские данные из куки

    //Смотрим данные о погоде из пользовательского хранилища
    //или из сервисов, в зависимости от условий
    $scope.loadWeatherInfo = function () {
        let loadWeatherInfoFromService = function () {
            let promise = WeatherParams.getWeatherInfo();
            if (promise == null) {
                console.log("loadWeatherInfo: WeatherParams.getWeatherInfo == null");
                return;
            }
            //загружаем данные о погоде из сервиса
            promise.then(
                function successCallback(response) {
                    let key = WeatherParams.getStorageKey();
                    //Добавляем в хранилище
                    UserStorage.putObject(key, response.data);
                    //Добавляем в интерфейс
                    $scope.weatherInfo = response.data;
                    console.log("getWeatherInfo - успех");
                },
                function errorCallback(response) {
                    console.log("getWeatherInfo - ошибка");
                }
            );
        }


        let currDate = new Date();
        
        let storageKey = WeatherParams.getStorageKey();
        if (storageKey == null)
            return;
        //Берем из хранилища
        let wthrInfo = UserStorage.getObject(storageKey);

        //Если в куки есть данные,
        //то проверяем актуальность
        if (wthrInfo != null) {

            //разница не должна превышать 5 минут
            let delta = (currDate - new Date(wthrInfo.Time)) / (60000); //Дельта в минутах
            //Если разница больше 5 минут, то 
            //информация в куки устарела, загружаем новые данные 
            //отображаем и сохраняем в куки
            if (delta > 5) {
                loadWeatherInfoFromService();
            }
            else {
                $scope.weatherInfo = wthrInfo;
            }

        }
        //Если в куки данных нет, то загружаем её
        //из погодного сервиса, отображаем и сохраняем в куки
        else {
            loadWeatherInfoFromService();
        }

        

    }


    $scope.id = 0;
    $interval($scope.loadWeatherInfo, 5000);

});
