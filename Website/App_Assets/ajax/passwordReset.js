// ===========================================
// Password Reset
// ===========================================

var AJAX = (function (AJAX) {
    "use strict";

    var passwordReset = {};
    passwordReset.resetPassword = function (token, password) {
        try {
            var url = "/WebServices/AdminWebService.asmx/ResetPassword";
            var parms = {};
            parms["token"] = token;
            parms["password"] = password;

            return AJAXHelper.executeAJAX(url, parms);
        }
        catch (ex) {
            console.log(ex);
            return AJAXHelper.errorCallback;
        }
    };


    // Public
    // =======================================
    AJAX.passwordReset = passwordReset;

    return AJAX;
})(AJAX || {});