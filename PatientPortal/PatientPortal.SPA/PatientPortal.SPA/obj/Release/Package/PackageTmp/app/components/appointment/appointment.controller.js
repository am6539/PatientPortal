angular.module('spaApp')
    .controller('AppointmentController', ['$scope', 'Params', 'AppointmentService', 'ModalService', '$location', 'LoadJsService', 'ContactService',
        function AppointmentController($scope, Params, AppointmentService, ModalService, $location, LoadJsService, ContactService) {
            
            LoadJsService.callJqueryBootstrap();
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

            $scope.optionsChooseDoctor = [
                { id: "0", name: "Chọn bác sĩ của bạn" },
                { id: "1", name: "Tư vấn một bác sĩ cho tôi" },
                { id: "2", name: "Tìm bác sĩ mà bạn biết" }
            ];

            //load contact info
            ContactService.get(function (data) {
                $scope.contact = data;
            });

            //Init time 
            $scope.giohens = getGioKham();

            AppointmentService.queryDoctors({ search: "" }, function (data) {
                $scope.doctors = data;
            });

            $scope.changeType = function (option) {
                if (option == 0) {
                    $("#choosedoctor").show(500);
                    $("#doctorSelected").show(500);
                    $("#searchDoctor").hide(500);
                    $("#quickviewProfile").hide(500);
                }
                if (option == 2) {
                    $("#searchDoctor").show(500);
                    $("#doctorSelected").hide(500);
                    $("#quickviewProfile").hide(500);
                    $("#choosedoctor").hide(500);
                    $scope.IspassPara = true;
                }
                if (option == 1) {
                    $("#searchDoctor").hide(500);
                    $("#doctorSelected").hide(500);
                    $("#choosedoctor").hide(500);
                    $scope.IspassPara = true;
                }
            }
            $scope.timeStamp = null;
            $scope.changeDoctor = function (value) {
                if (value != null) {
                    AppointmentService.getProfile({ id: value }, function (data) {
                        $scope.doctor = data;
                        $("#quickviewProfile").show(500);
                        $("#PhysicianIdMessage").hide(500);

                        if ($scope.appointment.Date != null) {

                            var from = $scope.appointment.Date.split("/");
                            var date = new Date(from[2], from[1] - 1, from[0], 0, 0, 0);
                            $scope.timeStamp = date.getTime();
                            AppointmentService.getScheduleExamine({ userId: value, startTime: $scope.timeStamp }, function (data) {
                                $scope.giohens = data;
                                $scope.appointment.Time = data[0];
                            });
                        }
                    });
                } else {
                    $("#quickviewProfile").hide(500);
                }
            }

            $scope.changeOrderDate = function (date) {
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
                        $scope.giohens = data;
                    });

                    $("#dateMessage").show(500);
                }
            }

            $scope.viewDoctorProfile = function (id, idModal) {
                var startTime = Date.parse(new Date());
                AppointmentService.queryScheduleExamine({ userId: id, startTime: startTime }, function (data) {
                    $scope.schedules = data;

                    ModalService.Open(idModal);

                });
            }

            $scope.transToInforOrderer = function (appointment) {
                activeShowTabInfo();
            }

            $scope.doSearch = function (idModal) {
                AppointmentService.queryDoctors({ search: $scope.searchText }, function (data) {
                    if (data.length > 0) {
                        $scope.doctors = data;
                        //$scope.doctor = data[0];
                        //$scope.appointment.PhysicianId = data[0].Id;
                        ModalService.Open(idModal);
                    }
                    else {
                        $scope.appointment.PhysicianId = "";
                    }
                });
            }

            $scope.chooseADoctor = function (value, idModal) {
                $scope.appointment.PhysicianId = value;
                AppointmentService.getDoctor({ id: value }, function (data) {
                    $scope.doctor = data;
                    $("#quickviewProfile").show(500);
                    $("#PhysicianIdMessage").hide(500);
                    ModalService.Close(idModal);
                });
            }

            $scope.registerInfo = function (appointment) {
                activeShowTabConfirm();
            }

            $scope.makeAppointment = function (appointment) {
                var hms = appointment.Time;   // your input string
                var a = hms.split(':'); // split it at the colons

                // minutes are worth 60 seconds. Hours are worth 60 minutes.
                appointment.Time = (+a[0]) * 60 + (+a[1]);

                appointment.Date = formatToDateTime(appointment.Date);
                if (appointment.PatientDoB != null) {
                    appointment.PatientDoB = formatToDateTime(appointment.PatientDoB);
                }

                AppointmentService.insertAppointment({ action: 'I' }, appointment, function (success) {
                    $location.url('/')
                }, function (error) { });
            }

            function formatToDateTime(date) {
                var from = date.split("/");
                return new Date(Date.UTC(from[2], from[1] - 1, from[0]));
            }

            $scope.closeModal = function (idModal) {
                ModalService.Close(idModal);
            }

            $scope.selectedAppointmentTab = function ($event) {

                $event.preventDefault();
                $('a[href="#appointment"]').addClass('selected');
                $('a[href="#infoOrderer"]').removeClass('selected');
                $('a[href="#checkandConfirm"]').removeClass('selected');

                $("#appointment").addClass("active in");
                $("#infoOrderer").removeClass("active in");
                $("#checkandConfirm").removeClass("active in");
            }

            $scope.selectedinfoOrdererTab = function ($event) {

                $event.preventDefault();
                //$("#infoOrderer").tab('show');
                $('a[href="#infoOrderer"]').addClass('selected');
                $('a[href="#appointment"]').removeClass('selected');

                $("#infoOrderer").addClass("active in");
                $("#appointment").removeClass("active in");
            }

            $scope.selectedcheckandConfirmTab = function ($event) {

                $event.preventDefault();
                //$("#checkandConfirm").tab('show');
                $('a[href="#checkandConfirm"]').addClass('selected');
                $('a[href="#infoOrderer"]').removeClass('selected');

                $("#checkandConfirm").addClass("active in");
                $("#infoOrderer").removeClass("active in");
            }

            function formatDate(date) {
                var from = date.split("/");
                date = new Date(from[2], from[1] - 1, from[0]);
                return date;
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

            function activeShowTabConfirm() {
                $("#checkandConfirm").tab('show');
                $('a[href="#checkandConfirm"]').addClass('selected');
                $('a[href="#infoOrderer"]').removeClass('selected');

                $("#checkandConfirm").addClass("active in");
                $("#infoOrderer").removeClass("active in");
            };

            function activeShowTabInfo() {
                $("#infoOrderer").tab('show');
                $('a[href="#infoOrderer"]').addClass('selected');
                $('a[href="#appointment"]').removeClass('selected');

                $("#infoOrderer").addClass("active in");
                $("#appointment").removeClass("active in");
            };
        }
    ]);