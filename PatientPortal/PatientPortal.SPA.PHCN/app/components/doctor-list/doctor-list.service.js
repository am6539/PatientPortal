angular.module('spaPHCN').factory('DoctorListServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'DoctorProfile', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + "DoctorProfile/Get",
                params: { id: '@id' },
                isArray: true
            },
            getProfile: {
                method: 'GET',
                url: Params.rootUrl + "DoctorProfile/Get/:id",
                params: { id: '@id' }
            }
        });
    }]);