//<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.6/angular.min.js"></script>
var app = angular.module("HomeApp", []);
app.controller("EmployeeController", function ($scope, $http) {
    $scope.btntext = "save";
    $scope.savedata = function () {
        $scope.btntext = "Wait..";
        $http({
            method: 'POST',
            url: '/Employee/create',
            data: $scope.Employee
        }).success(function (d) {
            $scope.btntext = "save";
                $scope.Employee = null;
            }).error(function () {
                alert("Failed");
            })
    }
});