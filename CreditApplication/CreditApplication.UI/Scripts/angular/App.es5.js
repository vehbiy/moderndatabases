'use strict';

var App = angular.module("CreditApplication", []).service('ApiService', ['$q', '$http', '$rootScope', ApiService]).run(['$rootScope', '$timeout', '$location', 'ApiService', Run]).config(["$locationProvider", function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false,
        rewriteLinks: false
    });
}]);
function Run($rootScope, $cookies, $timeout, $location) {
    window.gr = $rootScope;
}
App.controller("CreditCtrl", ["$scope", "$rootScope", "$timeout", CreditCtrl]);

function CreditCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;

    $scope.model = {};

    $scope.InitEdit = function () {
        $timeout(function () {});
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };
}

App.controller("PurchasePowerInputCtrl", ["$scope", "$rootScope", "$timeout", PurchasePowerInputCtrl]);

function PurchasePowerInputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;

    $scope.model = {};

    $scope.InitEdit = function () {
        $timeout(function () {});
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };
}

App.controller("VehicleInputCtrl", ["$scope", "$rootScope", "$timeout", VehicleInputCtrl]);

function VehicleInputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;
    $scope.model = {};

    $scope.InitEdit = function () {
        $timeout(function () {});
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };
}

App.controller("VehicleOutputCtrl", ["$scope", "$rootScope", "$timeout", VehicleOutputCtrl]);

function VehicleOutputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;

    $scope.model = {};

    $scope.InitEdit = function () {
        $timeout(function () {});
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };
}

function ApiService($q, $http, $rootScope) {
    var pendingRequests = [];

    var PATH = {
        Api: {
            Url: document.getElementById("ApiUrl").value // web configden ayarladığım url i layout içinden hidden input değeri olarak alıyorum
        }
    };

    PATH.Api.Current = PATH.Api.Url;

    this.GetIcon = function (id) {
        return Get("/Icon/" + id);
    };
}

