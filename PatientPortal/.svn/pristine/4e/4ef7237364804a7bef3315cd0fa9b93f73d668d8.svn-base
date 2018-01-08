jQuery(document).ready(function ($) {
    //training_classes
    $(".accordion").accordion({
        event: 'change',
        autoHeight: false/*,
		active: false,
		collapsible: true*/
    });
    $(".accordion.wide").bind("accordionchange", function (event, ui) {
        $("html, body").animate({ scrollTop: $("#" + $(ui.newHeader).attr("id")).offset().top }, 400);
    });

    $(".ui-accordion .ui-accordion-header").click(function () {
        $.bbq.pushState("#" + $(this).attr("id").replace("accordion-", ""));
    });

    //hashchange
    $(window).bind("hashchange", function (event) {
        var hashSplit = $.param.fragment().split("-");
        var hashString = "";
        for (var i = 0; i < hashSplit.length - 1; i++)
            hashString = hashString + hashSplit[i] + (i + 1 < hashSplit.length - 1 ? "-" : "");
        if (hashSplit[0].substr(0, 7) != "filter=") {
            $('.ui-accordion .ui-accordion-header#accordion-' + decodeURIComponent($.param.fragment())).trigger("change");
            $(".tabs_box_navigation a[href='#" + decodeURIComponent($.param.fragment()) + "']").trigger("click");
            $('.ui-accordion .ui-accordion-header#accordion-' + decodeURIComponent(hashString)).trigger("change");
        }
        $('.tabs .ui-tabs-nav [href="#' + decodeURIComponent(hashString) + '"]').trigger("change");
        $('.tabs .ui-tabs-nav [href="#' + decodeURIComponent($.param.fragment()) + '"]').trigger("change");
        if (hashSplit[0].substr(0, 7) != "filter=")
            $('.tabs .ui-accordion .ui-accordion-header#accordion-' + decodeURIComponent($.param.fragment())).trigger("change");
        $(".testimonials, .scrolling_list").trigger("updateSizesCustom");
        $(".image_carousel").trigger("updateSizesCustom");

        // get options object from hash
        var hashOptions = $.deparam.fragment();

        if (typeof (hashOptions.filter) != "undefined") {
            // apply options from hash
            $(".isotope_filters a").removeClass("selected");
            if ($('.isotope_filters a[href="#filter=' + hashOptions.filter + '"]').length)
                $('.isotope_filters a[href="#filter=' + hashOptions.filter + '"]').addClass("selected");
            else
                $(".isotope_filters li:first a").addClass("selected");
            $(".gallery:not('.horizontal_carousel')").isotope(hashOptions);
            //$(".timetable_isotope").isotope(hashOptions);
        }

        //open gallery details
        if (location.hash.substr(1, 21) == "gallery-details-close" || typeof (hashOptions.filter) != "undefined") {
            $(".gallery_item_details_list").animate({ height: '0' }, {
                duration: 200, easing: 'easeOutQuint', complete: function () {
                    $(this).css("display", "none")
                    $(".gallery_item_details_list .gallery_item_details").css("display", "none");
                }
            });
        }
        else if (location.hash.substr(1, 15) == "gallery-details") {
            var detailsBlock = $(location.hash);
            $(".gallery_item_details_list .gallery_item_details").css("display", "none");
            detailsBlock.css("display", "block");
            var galleryItem = $("#gallery-item-" + location.hash.substr(17));
            detailsBlock.find(".prev").attr("href", (galleryItem.prevAll(":not('.isotope-hidden')").first().length ? galleryItem.prevAll(":not('.isotope-hidden')").first().find(".open_details").attr("href") : $(".gallery:not('.horizontal_carousel')").children(":not('.isotope-hidden')").last().find(".open_details").attr("href")));
            detailsBlock.find(".next").attr("href", (galleryItem.nextAll(":not('.isotope-hidden')").first().length ? galleryItem.nextAll(":not('.isotope-hidden')").first().find(".open_details").attr("href") : $(".gallery:not('.horizontal_carousel')").children(":not('.isotope-hidden')").first().find(".open_details").attr("href")));
            var visible = parseInt($(".gallery_item_details_list").css("height")) == 0 ? false : true;
            var galleryItemDetailsOffset;
            if (!visible) {
                $(".gallery_item_details_list").css("display", "block").animate({ height: detailsBlock.height() }, 500, 'easeOutQuint', function () {
                    $(this).css("height", "100%");
                    $(location.hash + " .image_carousel").trigger("updateSizesCustom");
                });
                galleryItemDetailsOffset = $(".gallery_item_details_list").offset();
                $("html, body").animate({ scrollTop: galleryItemDetailsOffset.top - 10 }, 400);
            }
            else {
                /*$(".gallery_item_details_list").animate({height:'0'},{duration:200,easing:'easeOutQuint',complete:function() 
				{
					$(this).css("display", "none")*/
                //$(".gallery_item_details_list").css("height", "100%");
                galleryItemDetailsOffset = $(".gallery_item_details_list").offset();
                $("html, body").animate({ scrollTop: galleryItemDetailsOffset.top - 10 }, 400);
                $(location.hash + " .image_carousel").trigger("updateSizesCustom");
                /*$(".gallery_item_details_list").css("display", "block").animate({height:detailsBlock.height()},{duration:500,easing:'easeOutQuint'});
            }});*/
            }
        }
    }).trigger("hashchange");
});
