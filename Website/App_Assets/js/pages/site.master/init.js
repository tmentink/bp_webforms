// ===========================================
// Site Master
// ===========================================

!(function (window) {
	"use strict";

	// Ajax Timers
	// =======================================
	var ajax = {};
	ajax.timers = {};
	ajax.ignore = {
		// any ajax calls from the following urls will not start a loading timer
	};

	$cache(document).ajaxSend(function (event, request, settings) {
		if (ajax.ignore[settings.url]) { return; }

		var ajaxID = settings.url + settings.data;
		var timerLength = 1000;

		// create reference to the ajax call
		ajax.timers[ajaxID] = {};

		// show a loading overlay if the ajax call doesn't complete before the timer
		ajax.timers[ajaxID].timerID = setTimeout(function () {
			ajax.timers[ajaxID].triggered = true;
			loading.showOverlay();
		}, timerLength);
	});

	$cache(document).ajaxComplete(function (event, request, settings) {
		if (ajax.ignore[settings.url]) { return; }

		var ajaxID = settings.url + settings.data;

		// if the timer has been triggered then hide overlay
		if (ajax.timers[ajaxID].triggered) {
			loading.hideOverlay();
		}
		else {
			clearTimeout(ajax.timers[ajaxID].timerID);
		}

		delete ajax.timers[ajaxID];
	});

})(this);

