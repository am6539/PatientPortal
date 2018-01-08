angular.module('spaApp').factory('GalleryService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'Gallery', {}, {
            query: {
                method: 'GET',
                url: Params.rootUrl + 'Gallery/Query?departmentId=:departmentId',
                Params: { departmentId: '@departmentId' },
                isArray: true
            }
        });
    }]);