/// <reference path="D:\TAM\PROJECT\Patient_Project_2017_23_06\PatientPortal.SPA\PatientPortal.SPA\assets/js/jquery.fancybox-1.3.4.pack.js" />

angular.module('spaPHCN')
    .service('LoadJsService', function () {
        this.calJQuery = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery.min.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
        this.calJQueryUI = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery-ui.min.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
        this.calJInsideJs = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/skin/fpt-crd.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
        this.calJMigrate = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/jquery-migrate1-0-0.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
        this.calJFlexpaper = function loadScript() {
            var script = document.createElement("script")
            script.type = "text/javascript";
            script.src = 'assets/js/skin/flexpaper.js';
            document.getElementsByTagName("head")[0].appendChild(script);
        }
    });