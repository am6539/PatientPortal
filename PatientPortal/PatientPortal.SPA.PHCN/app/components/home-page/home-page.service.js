angular.module('spaPHCN').factory('HomeServices', ['$resource', 'Params',
    function ($resource, Params) {
        return $resource(Params.rootUrl + 'SPAPost', {}, {
            querySlider: {
                method: 'GET',
                url: Params.rootUrl + "Slider/Get",
                isArray: true
            }
        });
    }]);