angular.module('spaApp').factory('AppointmentService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            queryDoctors: {
                method: 'GET',
                url: Params.rootUrl + 'User/Get?search=:search',
                params: {
                    search: '@search'
                },
                isArray: true
            },
            queryScheduleExamine: {
                method: 'GET',
                url: Params.rootUrl + 'Schedule/QueryScheduleExamine?userId=:userId&startTime=:startTime',
                params: {
                    userId: '@userId', startTime: '@startTime'
                },
                isArray: true
            },
            insertAppointment: {
                method: 'POST',
                url: Params.rootUrl + 'Appointment/Transaction?action=:action',
                params: {
                    action: '@action'
                }
            },
            getDoctor: {
                method: 'GET',
                url: Params.rootUrl + 'User/GetById?id=:id',
                params: {
                    id: '@id'
                }
            },
            getScheduleExamine: {
                method: 'GET',
                url: Params.rootUrl + 'Schedule/GetScheduleExamine?userId=:userId&startTime=:startTime',
                params: {
                    userId: '@userId', startTime: '@startTime'
                },
                isArray: true
            },
            getProfile: {
                method: 'GET',
                url: Params.rootUrl + "DoctorProfile/Get/:id",
                params: { id: '@id' }
            }
        });
    }]);