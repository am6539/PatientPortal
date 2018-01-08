'use strict';

angular.module('spaPHCN')
    .controller("SearchController", [
    "$scope", "$location", "$route", "Params", "SearchService", 'PostListServices', 'PagerService',
    function ($scope, $location, $route, Params, SearchService, PostListServices, PagerService) {

        $scope.subTitle = "Kết quả tìm kiếm";
        $scope.pager = {};
        $scope.searchText = $route.current.params.searchText;

        $scope.setPage = function (page) {
            $scope.activeValue = page;
            var para = { languageCode: 'vi', pageIndex: page, numberInPage: Params.numberPerPage, priority: Params.newpriority, categoryId: 0, Search: $scope.searchText };

            PostListServices.queryPostPaging(para, function (data) {
                if (data != null) {
                    $scope.posts = data.PostListViewModels;
                    $scope.totalItems = data.TotalItem;

                    if (page < 1 || (page > $scope.pager.totalPages && $scope.pager.totalPages != null)) {
                        return;
                    }

                    // get pager object from service
                    $scope.pager = PagerService.GetPager($scope.totalItems, page, Params.numberPerPage);
                }

            });
        }

        $scope.setPage(1);
    }]);