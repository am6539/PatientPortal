angular.module('spaApp')
    .controller('PostDetailController', ['$scope', '$rootScope', 'Params', 'PostDetailService', '$route', 'CategoryService', 'PostService',
        function PostDetailController($scope, $rootScope, Params, PostDetailService, $route, CategoryService, PostService) {
            var Id = $route.current.params.id;
            PostDetailService.get({ Id: Id }, function (data) {
                if (data.Id > 0) {
                    $scope.post = data;

                    $rootScope.metaservice.setMetaPage(data.TitleTrans, data.TitleSEO, data.DescriptionSEO);
                    //set meta 
                    var robots = getMetaRobot(data);
                    $rootScope.metaservice.setMetaPost(data.Canonical, data.BreadcrumbsTitle, robots);
                    $rootScope.metaservice.setMetaFace(window.location.href, "Bài viết", data.TitleTrans, data.DescriptionTrans, data.Image);

                    PostService.queryPostByCategory({ languageCode: 'vi', priority: Params.newpriority, categoryId: data.CategoryId }, function (data) {
                        $scope.Relatedposts = data;

                        $(".scrolling_list_control_left").css("display", "block");
                        $(".scrolling_list_control_right").css("display", "block");
                    });
                }
            });
            
            PostService.queryPost({ languageCode: 'vi', priority: Params.hotpriority, categoryId: Params.postParentCategoryId }, function (data) {
                $scope.hotposts = data;
            });

            CategoryService.queryNewsCategory({ parentId: Params.postParentCategoryId }, function (data) {
                $scope.categories = data;
            });

            function getMetaRobot(data) {
                var robotArr = [];
                if (data.MetaRobotIndex == 1) {
                    robotArr.push('index');
                }
                if (data.MetaRobotFollow) {
                    robotArr.push('follow');
                }
                if (data.MetaRobotAdvanced) {
                    robotArr.push('advance');
                }
                var robots = '';
                if (robotArr.length > 1) {
                    for (var i = 0; i < robotArr.length - 1; ++i) {
                        robots = robots + robotArr[i] + ', ';
                    }
                    robots = robots + robotArr[robotArr.length - 1];
                }

                return robots;
            }
        }
    ]);