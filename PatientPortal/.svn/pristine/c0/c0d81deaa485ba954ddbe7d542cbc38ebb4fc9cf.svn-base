angular.module('spaApp')
    .controller('GalleryController', ['$scope', 'Params', 'GalleryService', '$route', 'DepartmentService', 'LoadJsService', '$timeout',
        function DepartmentController($scope, Params, GalleryService, $route, DepartmentService, LoadJsService, $timeout) {

            //get all department
            DepartmentService.query(function (data) {
                $scope.departments = data;
            });

            //get all gallery
            $scope.getGalleries = function (departmentId) {
                GalleryService.query({ departmentId: departmentId }, function (data) {
                    $timeout(function () {
                        $scope.galleries = data;
                        $scope.galleriesDetail = data;

                        LoadJsService.calJquery();
                        LoadJsService.calJqueryMigrate();
                        LoadJsService.calJqueryBa();
                        LoadJsService.calJqueryUI();
                        LoadJsService.calJqueryEA();
                        LoadJsService.calJqueryCaRoul();
                        LoadJsService.calJquerySliderControl();
                        LoadJsService.calJquerySlider();
                        LoadJsService.calJqueryAccordion();
                        LoadJsService.calJqueryTimeago();
                        LoadJsService.calJqueryHint();
                        LoadJsService.calJqueryIO();
                        LoadJsService.calJqueryIOMas();
                        LoadJsService.calJqueryFanc();
                        LoadJsService.calJqueryQtip();
                        LoadJsService.calJqueryBlockUI();
                        LoadJsService.callJqueryMain();
                    }, 1000);
                });
            }

            $scope.changeDepartment = function (departmentId) {
                GalleryService.query({ departmentId: departmentId }, function (data) {
                    $scope.galleries = data;
                    $scope.galleriesDetail = data;
                });
            }

            $scope.getGalleries(0);
        }
    ]);