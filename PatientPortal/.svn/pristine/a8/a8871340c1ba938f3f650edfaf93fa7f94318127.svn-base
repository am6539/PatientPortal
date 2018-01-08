
$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});
$("#menu-toggle-2").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled-2");
    $('#menu ul').hide();
    if ($(".wrapper-user").hasClass("hide")) {
        $(".wrapper-user").removeClass("hide")
        $(".wrapper-user").addClass("show")
    }
    else
    {
        $(".wrapper-user").removeClass("show")
        $(".wrapper-user").addClass("hide")
    }
        
});

function initMenu() {
    $('#menu ul').hide();
    $('#menu ul').children('.current').parent().show();
    //$('#menu ul:first').show();
    $('#menu li a').click(
      function () {
          var checkElement = $(this).next();
          if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
              return false;
          }
          if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
              $('#menu ul:visible').slideUp('normal');
              checkElement.slideDown('normal');
              return false;
          }
      }
      );
}

function setHeightNav() {
    $("#sidebar-wrapper").css("height", $("#wrapper").outerHeight()+150);
}
window.onload = setHeightNav();
