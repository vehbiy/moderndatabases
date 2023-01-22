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
