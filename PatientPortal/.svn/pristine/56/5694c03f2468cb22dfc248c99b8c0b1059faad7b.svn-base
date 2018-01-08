
appManagement.factory('AppointmentService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'User', {}, {
            queryDoctors: {
                method: 'GET',
                url: Params.rootUrl + 'User/Get?search=:search',
                params: {
                    search: '@search'
                },
                isArray: true
            },
            getDoctor: {
                method: 'GET',
                url: Params.rootUrl + 'User/GetById?id=:id',
                params: {
                    id: '@id'
                }
            },
            getDefaultDoctorByTag: {
                method: 'GET',
                url: Params.rootUrl + 'GetDefaultDoctor?search=:search',
                params: {
                    searc: '@search'
                }
            },
            queryScheduleExamine: {
                method: 'GET',
                url: Params.rootUrl + 'Schedule/QueryScheduleExamine?userId=:userId&startTime=:startTime',
                params: {
                    userId: '@userId', startTime: '@startTime'
                },
                isArray: true
            },
            getScheduleExamine: {
                method: 'GET',
                url: Params.rootUrl + 'Schedule/GetScheduleExamine?userId=:userId&startTime=:startTime',
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
            }
        });
    }]);