angular.module('spaPHCN').factory('FeatureDetailService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + "Feature/Get/:Id"
            }
        });
    }]);