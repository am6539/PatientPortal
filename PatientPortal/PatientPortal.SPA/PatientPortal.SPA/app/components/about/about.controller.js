angular.module('spaApp')
    .controller('AboutController', ['$scope', 'Params', 'AboutService', '$route',
        function AboutController($scope, Params, AboutService, $route) {
            var Id = $route.current.params.id;
            AboutService.get({ Id: Id }, function (data) {
                $scope.about = data;
            });
        }
    ]);