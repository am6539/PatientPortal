angular.module('spaPHCN').factory('DepartmentService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'Department', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + 'Department/Get/:id',
                Params: { id: '@id' }
            },
            query: {
                method: 'GET',
                url: Params.rootUrl + 'Department/Get',
                isArray: true
            }
        });
    }]);