angular.module('spaPHCN').factory('ServiceServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {

        });
    }]);