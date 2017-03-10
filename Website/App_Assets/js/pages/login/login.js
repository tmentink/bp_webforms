// ===========================================
// Login - Login
// ===========================================

var page = (function (page) {
    "use strict";
   
    var login = function () {
        var loginMethod = $cache("#txtUsername").val();
        var password = $cache("#txtPassword").val();

        var ajaxCall = AJAX.login.verifyLogin(loginMethod, password);
        ajaxCall.done(function (response) {
            var bool = AJAXHelper.processResponse(response, "boolean");

            if (bool === null) { _errorResponse(); return; }

            if (bool) {                
                window.location = "/home.aspx";
            }
            else {
                page.loginForm.showError(Resources.login.InvalidLogin);
                page.loginForm.errorStyles();
            }
        });

        ajaxCall.fail(_errorResponse);

        function _errorResponse() {
            page.loginForm.showError(Resources.login.CantAccessServer);
        }
    };


    // Public
    // =======================================
    page.login = login;

    return page;
})(page || {});