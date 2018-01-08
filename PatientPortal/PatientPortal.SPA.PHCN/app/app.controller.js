'use strict';

angular.
module('spaPHCN').controller('AppController', ['$scope', '$rootScope', '$location', "Params", 'ContactService', 'MetaService',
    function MainController($scope, $rootScope, $location, Params, ContactService, MetaService) {
        $rootScope.metaservice = MetaService;

        ContactService.get(function (data) {
            if (data != null) {
                $scope.contact = data;
                $rootScope.metaservice.setMetaPage(data.Name, data.Name, data.Name);
                $rootScope.metaservice.setMetaFace(window.location.href, "website", data.Name, data.Name, window.location.href + 'favicon.ico');
            }
        });

        $scope.search = function () {
            if ($scope.searchText != undefined) {
                $location.url('/search/' + $scope.searchText);
            }
        }
    }
]);