"use strict";

App.controller("VehicleInputCtrl", ["$scope", "$rootScope", "$timeout", VehicleInputCtrl]);

function VehicleInputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;
    //$scope.model = window.model;
    // $scope.colors = { Blue: true, Orange: true };

    //$scope.model.UsageTypeOnClick = function () {
    //    var result = 0;
    //    result += $scope.getFlagValue("Advance", 1);
    //    result += $scope.getFlagValue("Credit", 2);
    //    result += $scope.getFlagValue("Rent", 4);
    //    $scope.model.UsageType = result;
    //}

    $scope.InitEdit = function () {
        $timeout(function () {
            //$scope.model.InitUsageType();
        });
    };

    $scope.InitList = function () {
        $timeout(function () {});
    };

    //$scope.model.InitUsageType = function () {
    //    console.log($scope.model.UsageType);
    //    var x1 = $scope.checkFlag($scope.model.UsageType, 1);
    //    var x2 = $scope.checkFlag($scope.model.UsageType, 2);
    //    var x3 = $scope.checkFlag($scope.model.UsageType, 4);
    //    $scope.model.usageTypes = { Advance: x1, Credit: x2, Rent: x3 };
    //}

    $scope.checkFlag = function (value, flag) {
        return (value & flag) > 0;
    };

    $scope.getFlagValue = function (key, value) {
        var item = $scope.model.usageTypes[key];
        if (item) return value;else return 0;
    };
}

