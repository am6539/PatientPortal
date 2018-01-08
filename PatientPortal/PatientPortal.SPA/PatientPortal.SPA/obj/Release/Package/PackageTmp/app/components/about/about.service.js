angular.module('spaApp').factory('AboutService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'Configuration', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/Get/:Id",
                params: { Id: '@Id' }
            }
        });
    }]);