'use strict';

angular.module('spaPHCN')
    .controller("ContactController", [
    "$scope", "$location", "$route", "Params", "ContactService", 'alertService',
    function ($scope, $location, $route, Params, ContactService, alertService) {
        $scope.subTitle = "Liên hệ";
        ContactService.get(function (data) {
            $scope.contact = data;
        });

        $scope.sendMail = function (mail) {
            alertService.add("success", "Đang gửi góp ý!", 2500);
            ContactService.sendMail(mail, function (data) {
                if (data.$resolved) {
                    alertService.add("success", "Đã gửi thông tin góp ý thành công!", 1000);
                    $scope.contactForm.$setPristine();
                    $scope.mail = null;
                    $scope.contactForm.$submitted = false;
                }
                else {
                    alertService.add("danger", "Đã có lỗi xảy ra!", 1000);
                }
            });
        }
    }]);
