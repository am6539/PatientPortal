'use strict';

angular.module('spaApp')
    .controller("HomePageController", [
    "$scope", "$location", "$route", "Params", "HomePageServices", "LoadJsService", '$timeout',
    function ($scope, $location, $route, Params, HomePageServices, LoadJsService, $timeout) {
        // get danh muc Slider
        HomePageServices.getSlider(function (data) {
            $scope.sliders = data;
            $timeout(function () {

                LoadJsService.calJquery();
                LoadJsService.calJqueryMigrate();
                LoadJsService.calJqueryBa();
                LoadJsService.calJqueryUI();
                LoadJsService.calJqueryEA();
                LoadJsService.calJqueryCaRoul();
                LoadJsService.calJquerySliderControl();
                LoadJsService.calJquerySlider();
                LoadJsService.calJqueryAccordion();
                LoadJsService.calJqueryTimeago();
                LoadJsService.calJqueryHint();
                LoadJsService.calJqueryIO();
                LoadJsService.calJqueryIOMas();
                LoadJsService.calJqueryFanc();
                LoadJsService.calJqueryQtip();
                LoadJsService.calJqueryBlockUI();
                LoadJsService.callJqueryMain();
            }, 100);

            //timeago
            $("abbr.timeago").timeago();
            $(".scrolling_list_control_left").css("display", "block");
            $(".scrolling_list_control_right").css("display", "block");
        })

        // get danh muc Feature
        HomePageServices.getFeature(function (data) {
            data.forEach(function (item) {
                item.Description = item.Description.substring(0, 120);
            });
            $scope.features = data;
        })
        // get danh muc Post
        HomePageServices.getListPost({ languageCode: 'vi', priority: Params.hotpriority, categoryId: 0 },
            function (data) {
                $scope.lstPost = data;

                var myEl = angular.element(document.getElementsByName("sld0"));
                myEl.css('display', 'block');
            });

}]);
