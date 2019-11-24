'use strict';
weatherApp.factory('Cities', function ($http) {

    return {
        //Получить список групп
        getAll: function () {
            return $http({
                method: 'GET',
                //url: "/Scripts/angularJS/city/cityArray.json"
                url: "/api/City/"
                ,headers: {
                    'Content-Type': 'application/json'
                }
            });
        }
    }
});