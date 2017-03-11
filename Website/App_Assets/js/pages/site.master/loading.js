// ===========================================
// Site Master - Loading
// ===========================================

!(function (window) {
	"use strict";

	var overlay = {};
	overlay.target;
	overlay.spinner;

	var showLoadingOverlay = function () {
		var loader = $cache("#loader");

		if (loader.is(":visible")) { return; }

		loader.css("display", "block");
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
		overlay.target = $cache(".loader__img", $cache("#loader"))[0];
		overlay.spinner = new Spinner(options).spin(overlay.target);
	};

	var hideLoadingOverlay = function () {
		$cache("#loader").css("display", "none");

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

