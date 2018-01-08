angular.module('spaApp').factory('DoctorsServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'User', {}, {
            getDoctorList: {
                method: 'GET',
                url: Params.rootUrl + "User/GetDoctorList?pageIndex=:pageIndex&numberInPage=:numberInPage&search=:search",
                params: { pageIndex: '@pageIndex', numberInPage: '@numberInPage', search: '@search' }
            },
            getUserProfile: {
                method: 'GET',
                url: Params.rootUrl + "User/GetUserProfile?userId=:userId",
                params: { userId: '@userId' }
            },
        });
    }]);