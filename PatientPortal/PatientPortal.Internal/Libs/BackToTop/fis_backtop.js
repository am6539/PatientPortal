$(function () {
    // Back to top button
    var controlSection = $('.fis_backtop');
    $(window).scroll(function () {
        if ($(this).scrollTop() > 250)
            controlSection.css('visibility', 'visible');
        else
            controlSection.css('visibility', 'hidden');
    });
    controlSection.click(function () {
        $('body').animate({ scrollTop: 0 }, 1000);
    });
});