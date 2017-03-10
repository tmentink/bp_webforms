// ===========================================
// Login - Init
// ===========================================

!(function (window) {
    "use strict";

    $cache(document).ready(function () {           
        // Login Form
        // =======================================
        $cache("#txtPassword").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.login();
            }
        });

        $cache("#btnLogin").on("click", function () {
            page.login();
        });
        $cache("#btnLogin").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.login();
            }
        });

        $cache("#btnForgotPassword").on("click", function () {
            page.resetForm.clear();
            page.toggleForms();
        });
        $cache("#btnForgotPassword").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.resetForm.clear();
                page.toggleForms();
            }
        });


        // Reset Form
        // =======================================
        $cache("#btnReset").on("click", function () {
            page.resetPassword();
        });
        $cache("#btnReset").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.resetPassword();
            }
        });

        $cache("#btnBackToLogin").on("click", function () {
            page.loginForm.clear();
            page.toggleForms();
        });
        $cache("#btnBackToLogin").on("keyup", function (e) {
            if (e.keyCode == 13) {
                page.loginForm.clear();
                page.toggleForms();
            }
        });
    });

})(this);