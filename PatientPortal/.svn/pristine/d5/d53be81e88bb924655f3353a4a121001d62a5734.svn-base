jQuery(document).ready(function ($) {

	//slider
	$(".slider").carouFredSel({
		responsive: true,
		prev: {
			onAfter: onAfterSlide,
			onBefore: onBeforeSlide,
			easing: "easeInOutQuint",
			duration: 750
		},
		next: {
			onAfter: onAfterSlide,
			onBefore: onBeforeSlide,
			easing: "easeInOutQuint",
			duration: 750
		},
		auto: {
			play: true,
			pauseDuration: 5000,
			onAfter: onAfterSlide,
			onBefore: onBeforeSlide,
			easing: "easeInOutQuint",
			duration: 750
		}
	},
	{
		wrapper: {
			classname: "caroufredsel_wrapper caroufredsel_wrapper_slider"
		}
	});
	$(".slider").sliderControl({
		appendTo: $(".slider_content_box"),
		contentContainer: $(".slider_content_box")
	});

	//image carousel
	//image carousel with preloader
	var imageCarousel = function () {
		$(".image_carousel").each(function (index) {
			$(this).addClass("mc_preloader_" + index);
			$(".mc_preloader_" + index + " img:first").attr('src', $(".mc_preloader_" + index + " img:first").attr('src') + '?i=' + getRandom(1, 100000));
			$(".mc_preloader_" + index + " img:first").one("load", function () {
				$(this).prev(".mc_preloader").remove();
				$(this).fadeIn();
				var carouselOptions = {
					responsive: true,
					prev: {
						onAfter: onAfterSlide,
						onBefore: onBeforeSlide,
						easing: "easeInOutQuint",
						duration: 750
					},
					next: {
						onAfter: onAfterSlide,
						onBefore: onBeforeSlide,
						easing: "easeInOutQuint",
						duration: 750
					},
					auto: {
						play: false,
						pauseDuration: 5000,
						onAfter: onAfterSlide,
						onBefore: onBeforeSlide,
						easing: "easeInOutQuint",
						duration: 750
					}
				};
				$(".mc_preloader_" + index).carouFredSel(carouselOptions);
				if ($(".mc_preloader_" + index).children().length > 1) {
					$(".mc_preloader_" + index).sliderControl({
						appendTo: "",
						contentContainer: ""
					});
				}
				$(".mc_preloader_" + index + " li img").css("display", "block");
				$(".mc_preloader_" + index).trigger("updateSizesCustom"); //for width
				$(".mc_preloader_" + index).trigger("updateSizesCustom"); //for height
			}).each(function () {
				if (this.complete)
					$(this).load();
			});
		});
	};
	imageCarousel();


	//horizontal carousel
	$(".horizontal_carousel").carouFredSel({
		items: {
			visible: 4
		},
		scroll: {
			items: 1,
			easing: "swing",
			pauseOnHover: true
		},
		auto: {
			play: false,
			items: 1
		}
	});
	$(".our_clinic").trigger("configuration", {
		prev: '#our_clinic_prev',
		next: '#our_clinic_next'
	});
	$(".carousel").trigger("configuration", {
		prev: '#carousel_prev',
		next: '#carousel_next'
	});
	setTimeout(function () {
		$(".testimonials").trigger("configuration", {
			items: {
				visible: 2
			},
			prev: '#testimonials_prev',
			next: '#testimonials_next'
		});
	}, 1000);
});