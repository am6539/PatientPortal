angular.module('spaApp').factory('PostService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            queryPost: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/GetListPost?languageCode=:languageCode&priority=:priority",
                isArray: true,
                params: { languageCode: '@languageCode', priority: '@priority' }
            },
            queryPostPaging: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/GetPaging?languageCode=:languageCode&pageIndex=:pageIndex&numberInPage=:numberInPage&priority=:priority&categoryId=:categoryId",
                params: { languageCode: '@languageCode', pageIndex: '@pageIndex', numberInPage: '@numberInPage', priority: '@priority', categoryId: '@categoryId' }
            },
            queryNewsCategory: {
                method: 'GET',
                url: Params.rootUrl + 'Category/GetPostCategory?parentId=:parentId',
                params: { languageCode: '@parentId' },
                isArray: true
            },
            queryPostByCategory: {
                method: 'GET',
                url: Params.rootUrl + "SPAPost/GetListPost?languageCode=:languageCode&priority=:priority&categoryId=:categoryId",
                isArray: true,
                params: { languageCode: '@languageCode', priority: '@priority', categoryId: '@categoryId' }
            }
        });
    }]);