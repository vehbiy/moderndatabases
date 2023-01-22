var App = angular.module("CreditApplication", [])
    .service('ApiService', ['$q', '$http', '$rootScope', ApiService])
    .run(['$rootScope', '$timeout', '$location', 'ApiService', Run])
    .config(["$locationProvider", function ($locationProvider) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false,
            rewriteLinks: false
        });
    }]);
function Run($rootScope, $cookies, $timeout, $location) {
    window.gr = $rootScope;
}
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


"use strict";function CreditCtrl(n,t,i){window.gr=n;n.model=window.model;n.SelectVehicle=function(t){n.model.CreditAmount=t};n.InitEdit=function(){i(function(){})};n.InitList=function(){i(function(){})};n.func=function(){i(function(){})}}App.controller("CreditCtrl",["$scope","$rootScope","$timeout",CreditCtrl]);
App.controller("CreditCtrl", ["$scope", "$rootScope", "$timeout", CreditCtrl])

function CreditCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;
    $scope.model = window.model;

    $scope.SelectVehicle = function (value) {
        $scope.model.CreditAmount = value;
    }

	$scope.InitEdit = function () {
		$timeout(function () {
		});
    }

    $scope.InitList = function () {
		$timeout(function () {
		});
    }

    $scope.func = function () {
        $timeout(function () {
        });
    }
}

App.controller("PurchasePowerInputCtrl", ["$scope", "$rootScope", "$timeout", PurchasePowerInputCtrl])

function PurchasePowerInputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;
    $scope.model = window.model;

    $scope.model.CreditTypeOnChange = function () {
        $scope.CreditTypeChange();
    }

    $scope.SelectVehicle = function (value) {
        $scope.model.Price = value;
    }

    $scope.CreditTypeChange = function() {
        var model = $scope.model;
        $scope.model.UserTypeDisabled = false;

        if (model.CreditType != "1") {
            model.UserTypeDisabled = true;
            model.UserType = "1";
        }
    }

	$scope.InitEdit = function () {
        $timeout(function () {
            // $scope.model.UserType = "1";
            // $scope.model.CreditType = "1";
            $scope.CreditTypeChange();
        });
    }

    $scope.InitList = function () {
		$timeout(function () {
		});
    }
}

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


"use strict";function VehicleInputCtrl(n,t,i){window.gr=n;n.InitEdit=function(){i(function(){})};n.InitList=function(){i(function(){})};n.checkFlag=function(n,t){return(n&t)>0};n.getFlagValue=function(t,i){var r=n.model.usageTypes[t];return r?i:0}}App.controller("VehicleInputCtrl",["$scope","$rootScope","$timeout",VehicleInputCtrl]);
App.controller("VehicleInputCtrl", ["$scope", "$rootScope", "$timeout", VehicleInputCtrl])

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
    }

    $scope.InitList = function () {
		$timeout(function () {
		});
    }

    //$scope.model.InitUsageType = function () {
    //    console.log($scope.model.UsageType);
    //    var x1 = $scope.checkFlag($scope.model.UsageType, 1);
    //    var x2 = $scope.checkFlag($scope.model.UsageType, 2);
    //    var x3 = $scope.checkFlag($scope.model.UsageType, 4);
    //    $scope.model.usageTypes = { Advance: x1, Credit: x2, Rent: x3 };
    //}

    $scope.checkFlag = function (value, flag) {
        return (value & flag) > 0;
    }

    $scope.getFlagValue = function(key, value) {
        var item = $scope.model.usageTypes[key];
        if (item) return value;
        else return 0;
    }
}

App.controller("VehicleOutputCtrl", ["$scope", "$rootScope", "$timeout", VehicleOutputCtrl])

function VehicleOutputCtrl($scope, $rootScope, $timeout) {
    window.gr = $scope;

	$scope.model = {
	}


	$scope.InitEdit = function () {
		$timeout(function () {
			
		});
    }

    $scope.InitList = function () {
		$timeout(function () {
		});
    }
}

"use strict";

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


"use strict";function ApiService(){var n={Api:{Url:document.getElementById("ApiUrl").value}};n.Api.Current=n.Api.Url;this.GetIcon=function(n){return Get("/Icon/"+n)}}
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
    }
}