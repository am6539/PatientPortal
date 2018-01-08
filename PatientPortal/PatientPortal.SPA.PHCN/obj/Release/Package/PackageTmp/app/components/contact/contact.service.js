angular.module('spaPHCN').factory('ContactService', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            get: {
                method: 'GET',
                url: Params.rootUrl + 'Configuration/Get'
            },
            sendMail: {
                method: 'POST',
                url: Params.rootUrl + 'Configuration/SendMail'
            }
        });
    }]);