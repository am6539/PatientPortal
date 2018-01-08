'use strict';

angular.module('spaPHCN')
    .controller("PostListController", [
    "$scope", "$location", "$route", "Params", "PostListServices", 'PagerService', 'CategoryService',
    function ($scope, $location, $route, Params, PostListServices, PagerService, CategoryService) {

        $scope.subTitle = "Tin tức";
        $scope.pager = {};
        $scope.Id = $route.current.params.id;

        $scope.setPage = function (page) {
            $scope.activeValue = page;
            var para = { languageCode: 'vi', pageIndex: page, numberInPage: Params.numberPerPage, priority: Params.newpriority, categoryId: $scope.Id, Search: $scope.searchValue };

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

        //get category
        CategoryService.queryNewsCategory({ parentId: Params.postParentCategoryId }, function (data) {
            $scope.categories = data;
        });
    }]);
