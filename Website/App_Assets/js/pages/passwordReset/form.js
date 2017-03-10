// ===========================================
// PasswordReset - Form
// ===========================================

var page = (function (page) {
    "use strict";

    var showFormError = function (msg) {
        $cache("#password-info").removeClass("show");
        $cache("#password-error").addClass("show").html(msg);
        $cache("#txtNewPassword, #txtConfirmPassword").parent().addClass("has-danger");
    };

    var showFormSuccess = function () {
        $cache("#password-info, #password-error").removeClass("show");
        $cache(".form-group", $cache("#password-form")).removeClass("show");
        $cache("#password-success").addClass("show");
    };


    // Public
    // =======================================
    page.passwordForm = {
        showError: showFormError,
        showSuccess: showFormSuccess
    };

    return page;
})(page || {});