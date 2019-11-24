'use strict';
weatherApp.factory('UserStorage', function ($cookies, $window) {

    return {

        //
        putObject: function (key_, value_) {
            //$cookies.putObject(key_, value_);
            $window.localStorage[key_] = JSON.stringify(value_);
        },

        getObject: function (key_) {
            //return $cookies.getObject(key_);
            let value = $window.localStorage[key_];
            if (value != null)
                return JSON.parse(value);
            else
                return null;
        }
    }
});

//$window.localStorage["preved"] = JSON.stringify({ name: "medved" });
//let obj = JSON.parse($window.localStorage["preved"]);