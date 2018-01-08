angular.module('spaPHCN').factory('FeatureService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {

            query: {
                method: 'GET',
                url: Params.rootUrl + "Feature/Get",
                isArray: true
            }
        });
    }]);