// ===========================================
// Login - Init
// ===========================================

!(function (window) {
    "use strict";

    $cache(document).ready(function () {

        $cache("#btnResetPassword").on("click", function () {
            page.resetPassword();
        });
        $cache("#btnResetPassword").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.resetPassword();
            }
        });

        $cache("#txtConfirmPassword").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.resetPassword();
            }
        });

    });

})(this);