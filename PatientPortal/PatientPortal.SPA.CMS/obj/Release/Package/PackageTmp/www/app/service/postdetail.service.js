
appManagement.factory('PostService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            query: {
                method: 'GET',
                url: Params.rootUrl + 'SPAPost/GetPosts/:Id?languageCode=:languageCode',
                params: {
                    Id: '@Id', languageCode: '@languageCode'
                }
            },
            get: {
                method: "GET",
                url: Params.rootUrl + 'SPAPost/Get/:Id',
                params: { Id: '@Id' }
            },
            getAdvertise: {
                method: "GET",
                url: Params.rootUrl + 'Advertise/Get', isArray: true
            }
        });
}]);