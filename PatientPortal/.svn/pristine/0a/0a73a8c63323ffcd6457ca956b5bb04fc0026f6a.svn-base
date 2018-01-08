'use strict';

angular.module('spaPHCN')
    .controller("DepartmentDetailController", [
    "$scope", "$location", "$route", "Params", "DepartmentService", 'DepartmentDetailServices',
    function ($scope, $location, $route, Params, DepartmentService, DepartmentDetailServices) {
        $scope.subTitle = "Chuyên khoa";

        var Id = $route.current.params.id;
        DepartmentService.get({ id: Id }, function (data) {
            $scope.department = data;
        });

        DepartmentDetailServices.queryServiceDepartment({ departmentId: Id }, function (data) {
            $scope.investigateServices = [];
            $scope.treatmentServices = [];
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Category == 1) {
                        $scope.investigateServices.push(data[i]);
                    }
                    else {
                        $scope.treatmentServices.push(data[i]);
                    }
                }
            }
        })
    }]);
