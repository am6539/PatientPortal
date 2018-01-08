angular.module('spaPHCN').factory('DepartmentDetailServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            queryServiceDepartment: {
                method: 'GET',
                url: Params.rootUrl + 'DepartmentService/GetServices?departmentId=:departmentId',
                Params: { departmentId: '@departmentId' },
                isArray: true
            }
        });
    }]);