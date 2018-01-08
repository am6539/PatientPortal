angular.module('spaPHCN')
  .directive('loading', function () {
      return {
          restrict: 'E',
          replace: true,
          template: '<div class="loading"><img src="../../../assets/images/media/5/banner/loading.gif" width="50" height="50" />  Đang gửi...</div>',
          link: function (scope, element, attr) {
              scope.$watch('loading', function (val) {
                  if (val)
                      $(element).show();
                  else
                      $(element).hide();
              });
          }
      }
  })