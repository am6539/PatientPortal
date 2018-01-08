'use strict';

angular.
module('spaApp').controller('MainController', ['$scope', '$rootScope', "HomePageServices", "Params",
    'CategoryService', 'ContactService', 'PostService', 'DepartmentService', "LoadJsService", 'MetaService',
    function MainController($scope, $rootScope, HomePageServices, Params, CategoryService, ContactService,
        PostService, DepartmentService, LoadJsService, MetaService) {
        $rootScope.metaservice = MetaService;

        // get danh muc Post
        HomePageServices.getListPost({ languageCode: 'vi', priority: Params.hotpriority, categoryId: 0 },
        function (data) {
            $scope.lstPost = data;
        });

        ContactService.get(function (data) {
            $scope.contact = data;
            if (data != null) {
                $rootScope.metaservice.setMetaPage(data.Name, data.Name, data.Name);
                $rootScope.metaservice.setMetaFace(window.location.href, "website", data.Name, data.Name, window.location.href + 'favicon.ico');
            }
        });


        CategoryService.query(function (data) {
            var roots = nested(data);
            var i = getIndexValue(roots, Params.postParentCategoryId);
            if (i < roots.length + 1) {
                $scope.categories = roots[i];
            }
        });

        PostService.queryPostByCategory({ languageCode: Params.languageCode, priority: 0, categoryId: Params.aboutParentCategoryId }, function (data) {
            $scope.abouts = data;
        });

        DepartmentService.query(function (data) {
            $scope.departments = data;
        });
    }
]);

