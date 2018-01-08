angular.module('spaPHCN').factory('AboutService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'Configuration', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/GetPostAbout?languageCode=:languageCode",
                params: { languageCode: '@languageCode' },
                isArray: true
            }
        });
    }]);