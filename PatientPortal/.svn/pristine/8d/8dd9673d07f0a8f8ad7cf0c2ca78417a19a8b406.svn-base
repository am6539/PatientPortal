angular.module('spaPHCN')
    .controller('AboutController', ['$scope', 'Params', 'AboutService', '$route',
        function AboutController($scope, Params, AboutService, $route) {

            $scope.subTitle = "Giới thiệu chung";
            AboutService.get({ languageCode: Params.languageCode }, function (data) {
                $scope.about = data;
            });
        }
    ]);