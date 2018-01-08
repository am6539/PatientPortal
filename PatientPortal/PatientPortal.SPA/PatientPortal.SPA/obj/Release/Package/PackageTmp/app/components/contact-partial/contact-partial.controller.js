angular.module('spaApp')
    .controller('ContactPartialController', ['$scope', 'Params', 'ContactService',
        function ContactPartialController($scope, Params, ContactService) {
            ContactService.get(function (data) {
                $scope.contact = data;
            });
        }
    ]);