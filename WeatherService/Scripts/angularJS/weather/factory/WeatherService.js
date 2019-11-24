'use strict';
weatherApp.factory('WeatherService', function ($http) {

    return {
        //Получить список групп
        getAll: function () {
            return $http({
                method: 'GET',
                url: "/api/WeatherService/"
                , headers: {
                    'Content-Type': 'application/json'
                }
            });
        }
    }
});