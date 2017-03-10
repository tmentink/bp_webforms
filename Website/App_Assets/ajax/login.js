// ===========================================
// Login
// ===========================================

var AJAX = (function (AJAX) {
    "use strict";

    var login = {};
    login.verifyLogin = function (loginMethod, password) {
        try {
            var url = "/WebServices/AdminWebService.asmx/Login";
            var parms = {};
            parms["loginMethod"] = loginMethod;
            parms["password"] = password;

            return AJAXHelper.executeAJAX(url, parms);
        }
        catch (ex) {
            console.log(ex);
            return AJAXHelper.errorCallback;
        }
    };

    login.requestPasswordReset = function (loginMethod) {
        try {
            var url = "/WebServices/AdminWebService.asmx/RequestPasswordReset";
            var parms = {};
            parms["loginMethod"] = loginMethod;

            return AJAXHelper.executeAJAX(url, parms);
        }
        catch (ex) {
            console.log(ex);
            return AJAXHelper.errorCallback;
        }
    };


    // Public
    // =======================================
    AJAX.login = login;

    return AJAX;
})(AJAX || {});