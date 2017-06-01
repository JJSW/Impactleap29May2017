// All functionality relating to the modals
$(document).ready(function() {
  var modal = (function() {
    var scrollbarWidth = getScrollBarWidth();
    var $body = $("body"), $header_container_row = $(".header__container__row"),
        $signup_form_password_input = $(".signup-form__password-input");

    init();

    function init() {
      /* Attach event handlers */

      // Click outside modal removal
      $(".modal-block").click(function() {
        $(this).fadeOut(250);
        setTimeout(function() {modalTeardown();}, 250);
      })

      $(".modal-block__spacer").click(function(e) {
        e.stopPropagation();
      })

      // X modal removal
      $(".modal-block__close").click(function() {
        $(this).closest(".modal-block").fadeOut(250);
        setTimeout(function() {modalTeardown();}, 250);
      })

      // Register
      $("#register, #signupTest").click(function(e) {
        modalSetup();
        $("#modal-signup-form").fadeIn(250);
      });

      // Login
      $("#login, #loginTest").click(function() {
        modalSetup();
        $("#modal-login-form").fadeIn(250);
      });

      // Subscribe
      $("#subscribe, #subscribeTest").click(function() {
        modalSetup();
        $("#modal-thank-you-for-subscribing").fadeIn(250);
      });

      // Email Exists
      $("#existsTest").click(function() {
        modalSetup();
        $("#modal-email-already-exists").fadeIn(250);
      });

      // Password Show Button
      $(".btn--show-pass").click(passwordShowToggle);
    }

    // Adds styling on other elements on the page necessary for the modal
    function modalSetup() {
      $body.addClass("scroll-disabled");
      $body.css("padding-right", scrollbarWidth + "px");
      $header_container_row.css("margin-right", scrollbarWidth + "px");
    }

    // Removes styling on other elements on the page that were necessary for the modal
    function modalTeardown() {
      $body.removeClass("scroll-disabled");
      $body.css("padding-right", "0px");
      $header_container_row.css("margin-right", "0px");
    }

    // Toggles the show-hide button for the password field
    function passwordShowToggle() {
      if ($signup_form_password_input.prop("type") === "password") {
        $signup_form_password_input.prop("type", "text");
        $(this).children(".btn__show-text").css("display", "none");
        $(this).children(".btn__hide-text").css("display", "inline");
      } else {
        $signup_form_password_input.prop("type", "password");
        $(this).children(".btn__hide-text").css("display", "none");
        $(this).children(".btn__show-text").css("display", "inline");
      }
    }

    // Returns the width of the browser's scrollbar in px
    function getScrollBarWidth() {
      var $outer = $('<div>').css({visibility: 'hidden', width: 100, overflow: 'scroll'}).appendTo('body'),
          widthWithScroll = $('<div>').css({width: '100%'}).appendTo($outer).outerWidth();
      $outer.remove();
      return 100 - widthWithScroll;
    };

  })();
});
