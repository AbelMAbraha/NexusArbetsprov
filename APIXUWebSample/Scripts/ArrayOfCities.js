var app = angular.module("MyApp", []);
app.controller("HomeController", function ($scope, $http, $filter) {
    var list = [];
    $scope.runService = function (city) {
        if (!$scope.city) {
            /*DO NOTHING IF EMPTY STRING*/
        }
        else {
            list.push($scope.city)
            if (list.length - 1 == 3) {
                list.splice(0, 1);
            }
        }
        $http.post('/Home/GetWeather', JSON.stringify(list)).then(function (d) {
                $scope.weatherInfo = d.data;
                console.log($scope.weatherInfo);
            })
    }
});