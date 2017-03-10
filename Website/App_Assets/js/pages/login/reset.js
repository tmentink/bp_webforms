// ===========================================
// Login - Reset
// ===========================================

var page = (function (page) {
    "use strict";

    var resetPassword = function () {
        var loginMethod = $cache("#txtEmail").val();

        if (loginMethod == "") {
            page.resetForm.errorStyles();
        }
        else {         
            var ajaxCall = AJAX.login.requestPasswordReset(loginMethod);
            ajaxCall.done(function (response) {
                var bool = AJAXHelper.processResponse(response, "boolean");

                if (bool) {
                    page.resetForm.showMsg();
                }
                else {
                    _errorResponse()
                }               
            });

            ajaxCall.fail(_errorResponse);

            function _errorResponse() {
                page.resetForm.showError();
            };
        }        
    };


    // Public
    // =======================================
    page.resetPassword = resetPassword;

    return page;
})(page || {});