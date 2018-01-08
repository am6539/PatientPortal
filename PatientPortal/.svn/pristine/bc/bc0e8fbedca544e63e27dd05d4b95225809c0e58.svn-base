$(document).ready(function () {
    // Declare a proxy to reference the hub. 
    var notiHub = $.connection.notiHub;
    var key = localStorage.getItem("u-key");
    var name = localStorage.getItem("u-name");

    // Start Hub
    $.connection.hub.start().done(function () {
        notiHub.server.connect(key, name);
    });

    //Response Notification
    notiHub.client.getLastedNotification = function (userName, mess) {
        new PNotify({
            title: 'Thông báo nội bộ',
            text: 'Bạn nhận được một thông báo từ tài khoản ' + userName
        });

        $('#numberNoti').fadeIn();
        var countNoti = $("#numberNoti").text();
        if (countNoti != null) {
            countNoti = countNoti + 1;
            $("#numberNoti").text(countNoti);
        }
    };
    //Response Result
    notiHub.client.getPushStatus = function (mess) {
        if (mess != null) {
            new PNotify({
                title: 'Thông báo nội bộ',
                text: mess, type : 'success'
            });
        }
    };
    //Client push message to database
    $("#frm_Notification_System").on("submit", function (event) {
        var $this = $(this);
        var frmValues = $this.serialize();
        $.ajax({
            type: $this.attr('method'),
            url: $this.attr('action'),
            data: frmValues,
            //contentType: "application/json; charset=utf-8",
            //dataType: "json",
            success: function (result) {
                if(result.IsSuccess)
                {
                    var alert = result.Data;
                    var mess = result.Message;

                    $("#notificationCtrl-alert-submit").html(alert);
                    $("#frm_Notification_System").get(0).reset();
                    notiHub.server.pushMessage(mess);
                }
                else
                {
                }
                    
            },
            error: function (result) {
                alert("error");
            }
        })
        .done(function () {
        })
        .fail(function () {
        });
        event.preventDefault();
    });
});