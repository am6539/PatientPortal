'use strict';

angular.module('spaPHCN')
    .controller("DoctorListController", [
    "$scope", "$location", "$route", "Params", "DoctorListServices",
    function ($scope, $location, $route, Params, DoctorListServices) {

        $scope.subTitle = "Danh sách bác sĩ";

        var id = $route.current.params.id;

        $scope.getProfile = function () {
            DoctorListServices.getProfile({ id: id }, function (data) {
                $scope.profile = data;
            });
        }

        DoctorListServices.get(function (data) {
            $scope.profiles = data;
        });
       
    }]);
