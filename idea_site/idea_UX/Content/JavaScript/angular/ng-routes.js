/*AngularJS document*/

'use strict';
var app = angular.module('ngRoutesConfig', ['ngRoute']);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(true).hashPrefix('/');

    $routeProvider

        /*----home page routes region */
       .when('/', {
            templateUrl: 'ng-templates/home/about.html',
            controller: 'homeCtrl',
            caseInsensitiveMatch: true,
            title : "myStore"
        })

       .when('/user/register', {
           templateUrl: 'ng-templates/home/register.html',
           controller: 'homeCtrl',
           caseInsensitiveMatch: true,
           title: "Registration | myStore"
       })

       .when('/user/login', {
          templateUrl: 'ng-templates/home/login.html',
          controller: 'homeCtrl',
          caseInsensitiveMatch: true,
          title: "Login | myStore"

       })
        
       .when('/user/verification', {
           templateUrl: 'ng-templates/home/email-verification.html',
           controller: 'homeCtrl',
           caseInsensitiveMatch: true,
           title: "Account Verification | myStore"
       
       })
        /*----home page routes region */
}]);

app.run(['$location', '$rootScope', function ($location, $rootScope) {
    $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
        $rootScope.title = current.$$route.title;
    });
}]);