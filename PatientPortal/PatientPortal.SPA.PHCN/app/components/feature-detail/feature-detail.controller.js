'use strict';

angular.module('spaPHCN')
    .controller("FeatureDetailController", [
    "$scope", "$location", "$route", "Params", "FeatureDetailService",
    function ($scope, $location, $route, Params, FeatureDetailService) {

        $scope.subTitle = "Dịch vụ";
        var Id = $route.current.params.id;
        FeatureDetailService.get({ id: Id }, function (data) {
            $scope.feature = data;
        });
    }]);
