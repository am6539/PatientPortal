'use strict';

angular.module('spaPHCN')
    .controller("HomeController", [
    "$scope", "$location", "$route", "Params", "HomeServices", 'PostsServices', 'LoadJsService',
    function ($scope, $location, $route, Params, HomeServices, PostsServices, LoadJsService) {
        PostsServices.queryPost({ languageCode: 'vi', priority: Params.newpriority, categoryId: 0, numTop: Params.numTopPost }, function (data) {
            $scope.posts = data;
        });

        HomeServices.querySlider(function (data) {
            $scope.sliders = data;
            LoadJsService.calJInsideJs();
        });
    }]);