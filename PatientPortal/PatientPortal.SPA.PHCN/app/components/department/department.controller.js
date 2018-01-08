'use strict';

angular.module('spaPHCN')
    .controller("DepartmentController", [
    "$scope", "$location", "$route", "Params", "DepartmentService",
    function ($scope, $location, $route, Params, DepartmentService) {
        $scope.subTitle = "Chuyên khoa";

        DepartmentService.query(function (data) {
            $scope.departments = data;
        });
    }]);
