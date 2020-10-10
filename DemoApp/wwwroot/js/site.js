'use strict'

var myApp = angular.module('app', ['ui.router']);

/**
 * Using ui-router, add a state that accepts a customerId as state params
 * Using the stateParams customerId, query for their todos
 * use an input box and button to post new todos
 * mark todos complete
 */

myApp.config(function ($stateProvider) {
    var helloState = {
        name: 'hello',
        url: '/',
        templateUrl: '../html/hello.html',
        controller: 'helloController'
    }

    var aboutState = {
        name: 'about',
        url: '/about',
        templateUrl: '../html/about.html',
        controller: 'aboutController'
    }

    $stateProvider.state(helloState);
    $stateProvider.state(aboutState);
});

myApp.controller('helloController', ['$scope', function ($scope) {
    console.log('hello works');
}]);

myApp.controller('aboutController', ['$scope', function ($scope) {
    console.log('about works');
}]);