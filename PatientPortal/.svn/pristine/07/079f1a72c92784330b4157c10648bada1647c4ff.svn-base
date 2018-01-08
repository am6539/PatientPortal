;;;var wdH=0, wdW=0,isie= false,apis = [], galWidth=0;
winresize = function(){
    wdW = $(window).width();
    wdH = $(window).height();
  

};


function autoCutStr(prefix) {

    if (!prefix || prefix === undefined) {
        prefix = "autoCutStr_";
    }
    $('[class^="' + prefix + '"]').each(function () {
        if ($(this).length > 0) {
            var str = $(this).html();
            str = str.replace('<br/>','');
            str = str.replace('<br>','');
            $(this).html(str);
            var len = parseInt($(this).attr("class").substr($(this).attr("class").lastIndexOf("_") + 1));
            var length = str.length;
            if (length > len) {
                if (str.charAt(len) == ' ') {
                    str = str.substr(0, len);
                }
                else {
                    str = str.substr(0, len);
                    str = str.substr(0, str.lastIndexOf(" "));
                }
                $(this).html(str + "...");
            }
        }
         
    });
}

$(document).ready(function() {
    winresize();
    
    autoCutStr();
    
	if(document.domain=='manage.hoanmy.com')
	{
		$('.main-nav .nav a').each(function(i,e){
			var crrhref = $(this).attr('href').replace('http://www.hoanmy.com/','http://manage.hoanmy.com/')
			$(this).attr('href',crrhref)
		})
		$('.fmenu .nav a').each(function(i,e){
			var crrhref = $(this).attr('href').replace('http://www.hoanmy.com/','http://manage.hoanmy.com/')
			$(this).attr('href',crrhref)
		})
	}
	
    $('.site-nav li').each(function(i,e){
    	$(this).css('z-index', 30-i);
    })

    var slcrr = 0;
    var timeoutID;
    var sltotal = $('.slide-item').length;
    var delaytimer = 0;
    
    function showNextItem(){
        if(!$('.at-slider').hasClass('isPlay')){
            $('.at-slider').addClass('isPlay');
            slcrr ++;
            if(slcrr == sltotal)(slcrr = 0)
            showItem(slcrr);
            
        }
    }
    
    $('.at-nav li').click(function(){
        var nitem = $(this).index()
        if(!$('.at-slider').hasClass('isPlay')){
            $('.at-slider').addClass('isPlay');
            
            showItem(nitem);
            $('.at-nav li').removeClass('active');
            $(this).addClass('active');
        }
        
    })

    function showItem(id){
        $('.at-slider').addClass('isPlay');
        slcrr = id;
        if($('.slcrr').length){
            $('.slcrr').fadeOut(1000,function(){
                $(this).find('.sub').css('top',0)
            });
        }
        $('.sub-img').fadeOut(500);
        
        $('.slide-item').removeClass('slcrr').eq(id).delay(delaytimer).fadeIn(1000,function(){
             $('.at-nav li').removeClass('active').eq(id).addClass('active');
            
            $(this).find('.sub').each(function(index, val) {
               $(this).css('display','none').delay(index*300).fadeIn(500)
            })
            $(this).find('.sub-img').fadeIn(400)
            $('.at-slider').removeClass('isPlay');
            $(this).addClass('slcrr');
        })
        delaytimer = 400;
        clearTimeout(timeoutID);
        if(sltotal>1){
            timeoutID = setTimeout(function(){showNextItem();} ,5000);
        }
        
    }
    $('.btn-prev').click(function(){
        if(!$('.at-slider').hasClass('isPlay')){
            $('.at-slider').addClass('isPlay');
            slcrr --;
            if(slcrr == -1)(slcrr = sltotal-1)
            showItem(slcrr);
            
        }
        return false;
    });
    $('.btn-next').click(function(){
        if(!$('.at-slider').hasClass('isPlay')){
            $('.at-slider').addClass('isPlay');
            slcrr ++;
            if(slcrr == sltotal)(slcrr = 0)
            showItem(slcrr);
            
        }
        return false;
    });
    if($('.at-slider').length){
        $('.slide-item').each(function(i,e){
            var imgsrc = $(this).children('img').attr('src');
            $(this).children('img').remove()
            $(this).css('background-image','url('+imgsrc+')')
        })
        showItem(0);
    } 

    $('.mainnav-wrap').prepend('<div class="mob-mnav"></div>')
    $('.main-nav>ul>li').each(function(){
        if($(this).children('.submenu').length){
            $(this).addClass('haschild')
        }
    })
    $('.mob-mnav').click(function(){
        $('.main-nav').slideToggle(400)
        return false;
    })

    $('.header-right').prepend('<div class="mob-search"></div>');
    $('.mob-search').click(function(){
        $('.search').slideToggle(300)
        return false;
    })

    // $('.video-home').append($('.video-wrap'));
    // $('.hnews-wrap .container').append($('.popup-left'));
    $('.close-pop').click(function(){
        $('.popup-left').addClass('opacity');
    })

    // $('.img-video').fancybox({
    //      type: "iframe",
    //       helpers: {
    //         overlay: {
    //             locked: false
    //       }
    //     }
    // });
    // 
   
     

    
    if ($('.newsdt-slimg img').length>1) {
        $('.newsdt-slimg').nivoSlider({
            animSpeed: 500,
            directionNav:false,
            controlNav:false,
            pauseOnHover: false,
            pauseTime: 6000
        });
    }
    if ($('.banner img').length>1) {
        $('.banner').nivoSlider({
            animSpeed: 500,
            directionNav:false,
            controlNav:false,
            pauseOnHover: false,
            pauseTime: 3000
        });
    }

    if ($('.banner2 img').length>1) {
        $('.banner2').nivoSlider({
            animSpeed: 500,
            directionNav:false,
            controlNav:false,
            pauseOnHover: false,
            pauseTime: 3000
        });

        $('.banner2').removeClass('preloadimg');
    }

    $('.wrap-ch-htpp').append('<div class="clear"></div>')
   

    $('.item-info-news').mouseenter(function () {
        $('.item-info-news').removeClass('active');
        $('.number div').removeClass('active');
        $(this).addClass('active');
        var newsrc = $(this).find('a.hidden').attr('ref');
        var newnb = $(this).find('a.hidden').attr('name');
        if (newsrc != '') {
            $('.img-news').html('<img src="' + newsrc + '" alt="home"/>')
            $('.'+newnb).addClass('active')
        }

    })
    function hoverHome() {
        if ($('.item-info-news.active').next().length) {
            $('.item-info-news.active').next().trigger('mouseenter')
        } else {
            $('.item-info-news').eq(0).trigger('mouseenter')
        }
    }
    if ($('.item-info-news').length) {
        setInterval(function () {
            hoverHome()
        }, 4000)
        hoverHome()
    }
    $('.item-ch-htpp select').css({'opacity':0,'-khtml-appearance':'none'})
    $('.itm-select').change(function(){
        var val = $('option:selected',this).text();
        $(this).prev().text(val);
        $(this).prev();
        //$('.search-input').width(500 - $('.search-label').width());
    })

    if($('.system_h_wrap').length){
        $('.system_h_wrap').parents('body').addClass('removeland');
    }
    //$(".removeland").find('.lang').removeAttr("href");

    /*HOI DAP*/
    $('.lst-title').click(function(){
        var _parent=$(this).parent();
        if(_parent.hasClass('active')){
            _parent.removeClass('active');              
            _parent.find('.lst-content').slideUp(800);
            
        }else{
            $('.lst-item').removeClass('active');   
            $('.lst-content').slideUp();
            _parent.addClass('active');
            _parent.find('.lst-content').slideDown(800);
            
        }
        
    });
    if($('.lst-content1').length){
        $('.lst-content1').each(function(){
            if($(this).html() == '') $(this).remove()
        })
    }
    if($('.lst-ser').length){
        $('.lst-item').eq(0).find('.lst-title').trigger('click');
        
    }

    $('.career-title').click(function(event) {
        $(this).parent().toggleClass('active');
        $('.career-content').slideUp(400)
        $(this).next().slideToggle(400)
    });
    if($('.career-title').length){
        $('.career-title').eq(0).trigger('click')
    }
    $('.career-btn1').click(function(){
        $('.career-item.active').find('.career-text').slideUp(400);
        $('.career-item.active').find('.career-frame').slideDown(400)
        return false;
    })


    /*HOI DAP*/
    $('.faq-title').click(function(){
        var _parent=$(this).parent();
        if(_parent.hasClass('active')){
            _parent.removeClass('active');              
            _parent.find('.faq-content').slideUp();
            
        }else{
            $('.faq-item').removeClass('active');   
            $('.faq-content').slideUp();
            _parent.addClass('active');
            _parent.find('.faq-content').slideDown();
            
        }
        
    });

    if($('.faq-item').length){
        $('.faq-item').eq(0).find('.faq-title').trigger('click');
       // var linkhrf = $('.cb-submit-link').attr('href');
        
    }
    //$('.faqs-wrap').parent().next().append('<div class="clear"></div><a href="'+$('.cb-submit-link').attr('href')+'" class="show-faq">'+$('.cb-submit-link').attr('title')+'</a> <div class="clear"></div>')
    //    $('.show-faq').fancybox({
    //        type:'iframe',
    //        width :480,
    //        height: 210
    //    })

    $('.site-nav').append('<a class="mbo-menu"></a>')
    $('.mbo-menu').click(function(){
        $('.site-nav .nav').slideToggle(400)
        return false;
    })

    // tab
    $('.tab-nav a').click(function(){
        $('.tab-nav a').removeClass('active')
        $(this).addClass('active');
        $('.tab-content').hide();
        var tgtab = $(this).attr('href');
        $(tgtab).fadeIn(300);
        //console.log($(this).parent().index())
        if($('#serarr').length && $(this).parent().index() != 0){
            var topos = $('#serarr').position().top - 30;
            $('html,body').animate({scrollTop:topos}, '300')
        }
        return false;
    });
    if($('.tab-nav a').length) $('.tab-nav a').eq(0).trigger('click')

    if($('.homepage').length){
        $('<div class="container home-link"></div>').insertBefore('.top-content-in')
        $('.hotlink,.cn-wrap').appendTo('.home-link')
    }
    $('.hnews-wrap .container .row').append($('.news-home , .video-home'));

    $('.ctit-showmap , .showmap').fancybox({
        type: 'iframe'
    })
    $('.contact-frm .frm-row').append('<div class="clear"></div>');

    // Sys.Application.add_load(function() {
        // if($('.hideThanks').length){
            // $('.hideThanks').parent().prev().addClass('hidden')
            // $('.hideThanks').parent().next().addClass('hidden')
        // }
    // })

    $(".cn-slide").carouFredSel({
        circular: false,
        infinite: false,
        eight: "variable",
        auto    : true,
        pagination  : "#foo2_pag"
    });

    

});
$(window).resize(function(){
    winresize();
})
$(window).load(function(){
    winresize();

    if($('.jspVerticalBar').length && $('.partner-wrap').length){
        $('.content-bg2').addClass('partner-scr');
    }

    if($('.page-menu').length){
        var menuW = 0,menuP=0,menuL = $('.page-menu>ul>li').length;
        $('.page-menu>ul>li').each(function(index, el) {
            menuW += $(this).width();
        });
        menuP = Math.floor((645 - menuW)/ (menuL));
        if(menuP%2==0){
            menuP = menuP * 0.5 +5 + 'px';
        }else{
             menuP = (Math.floor(menuP * 0.5)+5) + 'px 0 ' + (Math.floor(menuP * 0.5+1)+5) +'px';
        }
        //console.log(menuP + '  ' + menuL + '  ' )
        $('.page-menu>ul>li a').css('padding','0 '+menuP)
    }
    var hmhei = $('.hmdetail').height()
    $('.hmdetail>.col1').css('min-height',hmhei)
    
})


$(window).load(function(){
    winresize();
   

    if (wdW > 1280){
        if($('#popupContent').length && $('#popupContent').children().length){
            if( $.cookie('popup') == undefined ){
                $('.apopup').fancybox({
                    'padding': 0,
                    autoSize : false,
                    //width    : "70%",
					'width'  : '763',
					'height'  : '640',
                    afterClose: function() {
                    $('#popupContent').remove();
                  }
                });
                $('.apopup').trigger('click');
                $.cookie('popup', 'closep', { expires: 0.01 });
            }
        } 
    }
})

