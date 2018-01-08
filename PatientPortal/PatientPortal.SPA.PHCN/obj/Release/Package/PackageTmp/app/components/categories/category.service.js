angular.module('spaPHCN').factory('CategoryService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'Category', {}, {
            queryNewsCategory: {
                method: 'GET',
                url: Params.rootUrl + 'Category/GetPostCategory?parentId=:parentId',
                params: { languageCode: '@parentId' },
                isArray: true
            },
            query: {
                method: 'GET',
                url: Params.rootUrl + 'Category/GetMenu',
                isArray: true
            }
        });
    }]);