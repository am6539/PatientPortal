angular.module('spaPHCN')
    .service('LoadJsService', function () {
        this.calJquery = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery.min.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        },
        this.calJqueryMig = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery-migrate1-0-0.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        },
        this.calJqueryUI = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery-ui.min.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        },
        this.calJqueryPlugin = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/skin/plugins.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        },
        this.calJqueryFlex = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/skin/flexpaper.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
    });