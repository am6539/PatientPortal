'use strict';

angular.module('spaPHCN')
    .controller("FeatureController", [
    "$scope", "$location", "$route", "Params", "FeatureService",
    function ($scope, $location, $route, Params, FeatureService) {

        $scope.subTitle = "Dịch vụ";

        FeatureService.query(function (data) {
            $scope.features = data;
        })
    }]);
