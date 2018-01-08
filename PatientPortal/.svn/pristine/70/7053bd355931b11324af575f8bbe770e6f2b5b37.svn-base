angular.module('spaPHCN').factory('PostDetailServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/Get/:Id",
                params: { Id: '@Id' }
            }
        });
    }]);