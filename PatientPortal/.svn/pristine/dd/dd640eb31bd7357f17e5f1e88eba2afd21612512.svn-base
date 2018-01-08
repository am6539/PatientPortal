angular.module('MyApp').controller('ChildDepartmentController', ['$scope', 'PostService', '$filter',
    '$route', '$timeout', "indexServices", "$q",
    function ($scope, PostService, $filter, $route, $timeout, indexServices, $q) {
        $scope.isShow = false;
        //get parentId parameter from Url
        var parentId = $route.current.params.id;
        var handler = 'CK';
        $('a[ng-href="/index/portfolio"]').parent('li').addClass('active');

        $scope.getAdvertise = function () {
            PostService.getAdvertise(function (data) {
                $scope.Advertises = data;
            });
        }

        $scope.getChildDept = function () {
            var promiseDepartment = indexServices.getDepartment(parentId);
            $scope.combineResult = $q.all([
                promiseDepartment
            ]).then(function (resp) {
                $scope.depts = resp[0].data;
            })
        }
        //$scope.getChildDept = function () {
        //    $scope.depts = IndexFactory.query({ handler: handler, parentId: parentId });
        //}
    }]);