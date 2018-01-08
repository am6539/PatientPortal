'use strict';

angular.module('spaPHCN')
    .controller("PostsController", [
    "$scope", "$location", "$route", "Params", "PostsServices", "CategoryService", 'LoadJsService',
    function ($scope, $location, $route, Params, PostsServices, CategoryService, LoadJsService) {

        $scope.subTitle = "Tin tức";
        $scope.posts = [];
        $scope.firstPosts = null;
        var postObj = {
            category: {},
            subPosts: [],
            firstPost: null
        }

        $scope.newposts = [];
        $scope.index = 0;

        $scope.post = {
            Flag: '',
            Author: "",
            CategoryId: 0,
            CategoryName: "",
            DescriptionTrans: "",
            Detail: null,
            Id: 0,
            Image: "",
            Priority: 0,
            PublishDate: "",
            TitleTran: "",
            WorkflowStateId: 3,
            WorkflowStateName: ""
        };

        $scope.load = function () {
            PostsServices.queryPost({ languageCode: 'vi', priority: Params.newpriority, categoryId: 0, numTop: Params.numTopPost }, function (data) {
                data.forEach(function (item) {
                    $scope.post = {
                        Flag: '',
                        Author: "",
                        CategoryId: 0,
                        CategoryName: "",
                        DescriptionTrans: "",
                        Detail: "",
                        Id: 0,
                        Image: "",
                        Priority: 0,
                        PublishDate: "",
                        TitleTran: "",
                        WorkflowStateId: 3,
                        WorkflowStateName: ""
                    };
                    $scope.post = item;
                    $scope.post.Flag = 'abc0' + $scope.index;
                    $scope.index = $scope.index + 1;
                    $scope.newposts.push($scope.post);
                })
                $scope.newposts = $scope.newposts;
                $("script[src='assets/js/skin/fpt-crd.js']").remove();
                $('.mob-mnav').remove();
                $('.mob-search').remove();
                LoadJsService.calJInsideJs();
            });
        }


        $scope.$on('$includeContentLoaded', function () {
            $(".item-info-news a[name^='abc']").attr('rel', 'abc0');
        });


        $scope.load();

        //get news - category list
        CategoryService.queryNewsCategory({ parentId: Params.postParentCategoryId }, function (categories) {
            var posts = [];
            if (categories.length > 0) {
                categories.forEach(function (item) {
                    PostsServices.queryPost({ languageCode: 'vi', priority: Params.newpriority, categoryId: item.Id, numTop: Params.numTopPost }, function (data) {
                        postObj = {
                            category: {},
                            subPosts: [],
                            firstPost: null
                        }
                        postObj.category = item;
                        
                        postObj.firstPost = data[0];
                        if (data.length > 0) {
                            postObj.subPosts = data.slice(1);
                        }
                        
                        $scope.posts.push(postObj);
                    });
                })
            }
        });
    }]);
