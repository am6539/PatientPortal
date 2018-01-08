angular.module('MyApp').controller('RSSController', ['$scope', "RSSService",
    function ($scope, RSSService) {
        $scope.rssVB = RSSService.query({ type: 'vb' });
        $scope.rssTB = RSSService.query({ type: 'tb' });
        $scope.rssTM = RSSService.query({ type: 'tm' });
    }]);