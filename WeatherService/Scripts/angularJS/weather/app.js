'use strict'
var weatherApp = angular.module('weatherApp', ["ngCookies"])
    .config(["$httpProvider", function ($httpProvider) {
        $httpProvider.defaults.headers.common['Content-Type'] = 'application/json';
        $httpProvider.defaults.headers.post['Content-Type'] = 'application/json';
    }]);
//$httpProvider.defaults.headers.get['My-Header'] = 'value'.
