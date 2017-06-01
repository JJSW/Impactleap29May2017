// All functionality relating to the header
$(document).ready(function() {
  var header = (function() {

    var didScroll, sideMenuActivated = false, prevScrollPos = 0;
    var $header = $(".header__container"), $window = $(window), $register = $("#register"),
        $hamburger = $("#hamburger"), $overlay = $(".overlay"), $sideMenu = $(".menu-navigation")
        $headerRow = $(".header__container__row"), $Ximg = $("#X");

    init();
    slideHeader();

    function init() {
      // Attach event handlers
      $window.scroll(function() {
        didScroll = true;
      });

      $Ximg.mouseover(function() {
        $Ximg.attr("src", "img/graphics/X.png");
      })

      $Ximg.mouseout(function() {
        $Ximg.attr("src", "img/graphics/X2.png");
      })

      $hamburger.click(toggleSideMenu);
      $Ximg.click(toggleSideMenu);

      // Checks every 200ms whether or not to call slideHeader()
      setInterval(function() {
        if (didScroll) {
          slideHeader();
          didScroll = false;
        }
      }, 200);
    }

    // Hides the header if scrolling down, shows it if scrolling up.  Changes styles if header
    // is at the absolute top of page or not.
    function slideHeader() {
      if (!sideMenuActivated) {
        var currScrollPos = $window.scrollTop();

        // Changes style if at top of page or not
        if (currScrollPos == 0) { // at top of
          if($("header").hasClass("kontrola")){
            $register.removeClass("btn--register--style2");
            $register.addClass("btn--register--style3");

            $(".header__container").removeClass("header__container2");
            $(".hamburger-inner").removeClass("hamburger-inner2");
            $(".btn__label").removeClass("btn__label2");
            $("#hederimg2").attr("src","img/logos/impactleap-logo-gray.png");
            $("#hederimg1").attr("src","img/logos/impactleap-logo-white.png");
          }else{
            $register.removeClass("btn--register--style2");
            $register.addClass("btn--register--style1");
          }
          $header.removeClass("header--alt");

            // $header.removeClass("header__container2");
        } else { // not at top of page
          if($("header").hasClass("kontrola")){
            $register.addClass("btn--register--style2");
            $register.removeClass("btn--register--style3");

            $(".header__container").addClass("header__container2");
            $(".hamburger-inner").addClass("hamburger-inner2");
            $(".btn__label").addClass("btn__label2");
            $("#hederimg2").attr("src","img/logos/impactleap-logo-black.png");
            $("#hederimg1").attr("src","img/logos/impactleap-logo-gray.png");
          }else{
            $register.removeClass("btn--register--style1");
            $register.addClass("btn--register--style2");
          }
          $header.addClass("header--alt");

            // $header.addClass("header__container2");
        }

        // Hides/shows header when scrolling down/up
        if(prevScrollPos < currScrollPos) { // scrolling down
          $header.css("top", "-110px");
        } else { // scrolling up
          $header.css("top", "0px");
        }

        prevScrollPos = currScrollPos;
      }
    }

    // Toggles the side menu
    function toggleSideMenu() {
      if (!$hamburger.hasClass("is-active")) {
        $hamburger.addClass("is-active");
        $hamburger.css("visibility", "hidden");
        $sideMenu.addClass("menu-navigation--expanded");
        $overlay.fadeIn(200);
		$("body").css("overflow-y", "hidden");
        sideMenuActivated = true;
      } else {
        $hamburger.removeClass("is-active");
        $hamburger.css("visibility", "visible");
        $sideMenu.removeClass("menu-navigation--expanded");
        $overlay.fadeOut(200);
		$("body").css("overflow-y", "scroll");
        sideMenuActivated = false;
      }
    }

  })();
});
