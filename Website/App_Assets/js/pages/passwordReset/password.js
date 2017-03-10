// ===========================================
// PasswordReset - Password
// ===========================================

var page = (function (page) {
    "use strict";

    var getErrorMsg = function (errors) {
        var msg = "<div style='text-align: left;'>";

        for (var i = 0, i_end = errors.length; i < i_end; i++) {
            msg += errors[i] + "<br/>";
        }
        msg += "</div>";

        return msg;
    };

    var resetPasswordAJAX = function (token, password) {
        var ajaxCall = AJAX.passwordReset.resetPassword(token, password);
        ajaxCall.done(function (response) {
            var bool = AJAXHelper.processResponse(response, "boolean");

            if (bool === null) { _errorResponse(); return; }

            if (bool) {
                page.passwordForm.showSuccess();
            }
        });

        ajaxCall.fail(_errorResponse);

        function _errorResponse() {
            page.passwordForm.showError(Resources.passwordReset.CantAccessServer);
        }
    };

    var resetPassword = function () {
        var newPassword = $cache("#txtNewPassword").val();
        var confirmPassword = $cache("#txtConfirmPassword").val();
        var pass = validation.validatePassword(newPassword, confirmPassword);

        if (pass.isValid) {
            var token = $.QueryString["token"];
            resetPasswordAJAX(token, newPassword);
        }
        else {
            var errorMsg = getErrorMsg(pass.errors);
            page.passwordForm.showError(errorMsg);
        }
    };


    // Public
    // =======================================
    page.resetPassword = resetPassword;

    return page;
})(page || {});