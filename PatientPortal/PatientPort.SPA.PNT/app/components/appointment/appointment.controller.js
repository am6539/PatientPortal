angular.module('MyApp').controller('appointmentController', ['$scope', '$uibModal', 'AppointmentService', '$location', function ($scope, $uibModal, AppointmentService, $location) {
    $scope.appointment = {
        Date: moment(new Date()).format("DD/MM/YYYY"),
        Time: '',
        PhysicianId: '',
        PatientId: '',
        Symptom: '',
        Status: 1,
        PatientName: '',
        PatientAddress: '',
        PatientEmail: '',
        PatientPhone: '',
        PatientGender: null,
        PatientDoB: null
    };
    $scope.IspassPara = false;
    var valueSelectedType = null;

    $scope.doctor = null;
    $scope.initAppointment = function () {
        $scope.renderTimeDefault();
    };
    //get doctor
    $scope.getDoctor = function () {
        AppointmentService.queryDoctors({ search: "" }, function (data) {
            $scope.doctors = data;
        });
    };

    //change doctor select option
    $scope.changeDoctor = function (value) {
        if (value != null) {
            AppointmentService.getDoctor({ id: value }, function (data) {
                $scope.doctor = data;
                $("#quickviewProfile").show(500);
                $("#PhysicianIdMessage").hide(500);
            });
            if ($scope.appointment.Date != null) {
                AppointmentService.getScheduleExamine({ userId: value, startTime: $scope.timeStamp }, function (data) {
                    $scope.schedules = data;
                });
            }
        } else {
            $("#quickviewProfile").hide(500);
        }
    };

    $scope.transToInforOrderer = function () {
        $scope.appointment.Date = $("#dateAppointment").val();
        if ($scope.appointment.Date != null) {
            activeShowTabInfo();
        }
        else {
            $("#dateMessage").show(500);
        }
    };

    $scope.showDoctorList = function (searchText) {
        AppointmentService.queryDoctors({ search: searchText }, function (data) {
            $scope.doctors = data;

            $('#myModal').modal('show');
        });
    };

    //get time in schedule of a doctor
    $scope.timeStamp = null;
    $scope.changeDate = function (date) {
        alert("" + date);
        var doctorId = $("#selectPhysician option:selected").val().split(':')[1];
        if (doctorId == undefined) {
            $("#PhysicianIdMessage").show(500);
        }
        else {
            $scope.appointment.Date = date;
            var from = date.split("/");
            date = new Date(from[2], from[1] - 1, from[0], 0, 0, 0);
            $scope.timeStamp = date.getTime();
            AppointmentService.getScheduleExamine({ userId: doctorId, startTime: date.getTime() }, function (data) {
                $scope.schedules = data;
            });

            $("#dateMessage").show(500);
        }
    };

    //active tab
    function activeShowTabInfo() {
        $("#infoOrderer").tab('show');
        $('a[href="#infoOrderer"]').parent('li').addClass('active');
        $('a[href="#appointment"]').parent('li').removeClass('active');

        $("#infoOrderer").addClass("active in");
        $("#appointment").removeClass("active in");
    };

    $scope.searchDoctorByTag = function (search) {
        if (valueSelectedType == 1) {
            AppointmentService.queryDoctors({ search: search }, function (data) {
                if (data.length > 0) {
                    $scope.doctor = data[0];
                    $scope.appointment.PhysicianId = data[0].Id;
                }
                else {
                    $scope.appointment.PhysicianId = "";
                }
            });
        }
    };

    function activeShowTabConfirm() {
        $("#checkandConfirm").tab('show');
        $('a[href="#checkandConfirm"]').parent('li').addClass('active');
        $('a[href="#infoOrderer"]').parent('li').removeClass('active');

        $("#checkandConfirm").addClass("active in");
        $("#infoOrderer").removeClass("active in");
    };

    $scope.registerInfo = function (appointment) {
        $scope.appointment.PatientDoB = $("#ngaysinh").val();
        activeShowTabConfirm();
        $scope.TimeOrder = appointment.Time;
        $scope.DateOrder = $("#dateAppointment").val();
        $scope.DoBReview = $("#ngaysinh").val();
    };

    //show doctor detail
    $scope.viewDoctorProfile = function (id) {
        var startTime = Date.parse(new Date());
        AppointmentService.queryScheduleExamine({ userId: id, startTime: startTime }, function (data) {
            $scope.schedules = data;
            //$('#collapseThongTinModal').modal('toggle');

            console.log('opening pop up');
            var modalInstance = $uibModal.open({
                templateUrl: 'doctor_profile.html',
            });
        });
    };

    $("#selectDoctor").on('change', 'select', function (e) {
        var optionSelected = $("option:selected", this);
        valueSelectedType = this.value;
        //hideControlselectDoctor();
        if (valueSelectedType == 0) {
            $("#doctorSelected").show(500);
            $("#searchDoctor").hide(500);
            $("#quickviewProfile").hide(500);
            $scope.IspassPara = true;
        }
        if (valueSelectedType == 2) {
            $("#searchDoctor").show(500);
            $("#doctorSelected").hide(500);
            $("#quickviewProfile").hide(500);
            $scope.IspassPara = true;
        }
        if (valueSelectedType == 1) {
            $("#searchDoctor").hide(500);
            $("#doctorSelected").hide(500);
            $scope.IspassPara = true;
        }
    });

    function hideControlselectDoctor() {
        $("#doctorSelected").hide(500);
        $("#searchDoctor").hide(500);
        $("#quickviewProfile").hide(500);
    };

    $scope.makeAppointment = function (item) {
        var hms = item.Time;   // your input string
        var a = hms.split(':'); // split it at the colons

        // minutes are worth 60 seconds. Hours are worth 60 minutes.
        item.Time = (+a[0]) * 60 + (+a[1]);

        item.Date = formatDate(item.Date);
        if (item.PatientDoB != null)
            item.PatientDoB = formatDate(item.PatientDoB);
        AppointmentService.insertAppointment({ action: 'I' }, item, function (success) {
            $location.url('/')
        }, function (error) { });
    };

    function formatDate(date) {
        var from = date.split("/");
        date = new Date(from[2], from[1] - 1, from[0]);
        return date;
    };

    //Init time 
    $scope.renderTimeDefault = function () {
        $scope.giohens = getGioKham();
        $scope.getDoctor();
    };

    $scope.cancelAppointment = function () {
        $location.url('/')
    };

    $scope.makeAppointmentDoctor = function (value) {
        $scope.appointment.PhysicianId = value;
        AppointmentService.getDoctor({ id: value }, function (data) {
            $scope.doctor = data;
            $("#quickviewProfile").show(500);
            $("#PhysicianIdMessage").hide(500);
        });
    };

    function getGioKham() {
        var now = moment().hours(8).minutes(0).seconds(0).milliseconds(0);
        var max = moment().hours(19).minutes(0).seconds(0).milliseconds(0);
        var gio = [];
        var duration = moment.duration({ 'minutes': 15 });
        now = now.add(duration);
        while (now < max) {
            gio.push(now.format('HH:mm'));
            now = now.add(duration);
        }
        return gio;
    };

}]);
