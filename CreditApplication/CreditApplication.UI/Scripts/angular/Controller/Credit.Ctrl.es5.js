"use strict";

App.controller("CreditCtrl", ["$scope", "$rootScope", "$timeout", CreditCtrl]);

function CreditCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;
    $scope.model = window.model;

    $scope.SelectVehicle = function (value) {
        $scope.model.CreditAmount = value;
    };

    $scope.InitEdit = function () {
        $timeout(function () {});
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };

    $scope.func = function () {
        $timeout(function () {});
    };
}

