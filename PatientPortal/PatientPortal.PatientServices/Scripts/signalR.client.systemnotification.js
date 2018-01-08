$.getScript('http://localhost:48859/Scripts/jquery.signalR-2.2.2.min.js', function () {
    $.getScript('http://localhost:48859/signalr/hubs', function () {
        $.connection.hub.url = 'http://localhost:48859/signalr';
        var notiHub = $.connection.notiHub;
        var key = localStorage.getItem("u-key");
        var name = localStorage.getItem("u-name");

        //Response Notification
        notiHub.client.getLastedNotification = function (userName, mess) {
            new PNotify({
                title: 'Thông báo nội bộ',
                text: 'Bạn nhận được một thông báo từ tài khoản ' + userName
            });

            //set icon has notification
            $('#numberNoti').fadeIn();
            var countNoti = $("#numberNoti").text();
            if (countNoti != null) {
                countNoti = parseInt(countNoti) + 1;
                $("#numberNoti").text(countNoti);
            }
        };

        $.connection.hub.start({ jsonp: true }).done(function () {
            notiHub.server.connect(key, name);
        });
    });
});