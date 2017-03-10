// ===========================================
// Site Master - Loading
// ===========================================

!(function (window) {
	"use strict";

	var overlay = {};
	overlay.target;
	overlay.spinner;

	var showLoadingOverlay = function () {
		var wrapper = $cache("#loading__wrapper");

		if (wrapper.is(":visible")) { return; }

		wrapper.css("display", "block");
		var options = {
			lines: 12,
			length: 25,
			width: 10,
			radius: 35,
			trail: 75,
			corners: 0.5,
			shadow: true,
			hwaccel: true
		};

		if (bp.min_lg.matches) {
			options.length = 40;
			options.width = 15;
			options.radius = 50;
		}

		// create new spinner and store a reference
		overlay.target = $cache("#loading__img")[0];
		overlay.spinner = new Spinner(options).spin(overlay.target);
	};

	var hideLoadingOverlay = function () {
		$cache("#loading__wrapper").css("display", "none");

		// stop the spinner if one exists
		if (overlay.spinner instanceof Spinner) {
			overlay.spinner.stop(overlay.target);
		}
	};


	// Public
	// =======================================
	window.loading = {
		showOverlay: showLoadingOverlay,
		hideOverlay: hideLoadingOverlay
	};

})(this);

