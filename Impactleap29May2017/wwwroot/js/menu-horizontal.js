$(document).ready(function() {
	var menu = (function() {
		var $more = $("#more"), $menu = $(".horizontal-navigation__menu"),
			$menuItems = $(".horizontal-navigation__menu li"),
			$submenu = $(".horizontal-navigation__submenu"),
			$submenuItems = $(".horizontal-navigation__submenu li");
		var resizeFlag = true, oldSize = $(window).width(), newSize = oldSize;

		_init();

		function _init() {
			orderMenu();
			setInterval(orderMenu, 150);

			// Event handlers
			$(window).resize(function() {
				resizeFlag = true;
				newSize = $(window).width();
			});

			$more.hover(function() {
				if (newSize > 768) {
					$(this).addClass("horizontal-navigation__item--open");
					$submenu.css("display", "block");
				}
			});

			$more.mouseleave(function() {
				if (newSize > 768) {
					$(this).removeClass("horizontal-navigation__item--open");
					$submenu.css("display", "none");
				}
			});
		}

		// Changes the display of the menu and submenu elements
		function orderMenu() {
			if (resizeFlag) {
				if (newSize > 768) {
					var remainingWidth = $menu.width() - Math.ceil($menu.children().first().width()); //overall width - all li
					var numOfLi = Math.ceil(remainingWidth / 150) - 1;

					if (oldSize > newSize || oldSize == newSize) { // resize down
						$menuItems.slice(numOfLi).css("display", "none");
						$submenuItems.slice(numOfLi).css("display", "block");
						$submenuItems.slice(0, numOfLi - 1).css("display", "none");
					} else if (oldSize < newSize) { // resize up
						$menuItems.slice(0, numOfLi).css("display", "flex");
						$submenuItems.slice(0, numOfLi).css("display", "none");
						$submenuItems.slice(numOfLi + 1).css("display", "block");
					}

					$more.css("display", "flex");

					oldSize = newSize;
					resizeFlag = false;
				} else {
					$menuItems.not("#more").css("display", "none");
				}
			}
		}
	})();
});
