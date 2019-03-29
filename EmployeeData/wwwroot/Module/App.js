var app = angular.module('myApp', ['ngRoute']);

app.config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {

    $routeProvider.when('/EmployeeList', { //Routing for show list of employee
        templateUrl: '/Module/EmployeeList.html',
        controller: 'EmployeeCtrl'
    }).when('/AddEmployee', { //Routing for add employee
        templateUrl: '/Module/Edit.html',
        controller: 'EmployeeCtrl'
    })
        .when('/EditEmployee/:empId', { //Routing for geting single employee details
            templateUrl: '/Module/EmployeeList.html',
            controller: 'EmployeeCtrl'
        })
        .when('/DeleteEmployee/:empId', { //Routing for delete employee
            templateUrl: '/Module/Delete.html',
            controller: 'EmployeeCtrl'
        })
        .otherwise({ //Default Routing
            controller: 'EmployeeCtrl'
        })
}]);