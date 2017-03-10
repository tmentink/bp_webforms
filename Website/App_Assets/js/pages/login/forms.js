// ===========================================
// Login - Forms
// ===========================================

var page = (function (page) {
    "use strict";
   
    var toggleForms = function () {
        $cache("#login-form, #reset-form").toggleClass("show");
    };


    // Login Form
    // =======================================
    var clearLoginForm = function () {
        $cache("#login-error").removeClass("show");
        $cache("#txtUsername, #txtPassword").val("");
        $cache("#txtUsername, #txtPassword").parent().removeClass("has-danger");
    };

    var showLoginFormError = function (msg) {
        $cache("#login-error").addClass("show").html(msg);     
    };

    var loginFormErrorStyles = function () {
        $cache("#txtUsername, #txtPassword").parent().addClass("has-danger");
    };


    // Reset Form
    // =======================================
    var clearResetForm = function () {
        $cache("#reset-msg, #reset-error").removeClass("show");
        $cache("#txtEmail, #btnReset").removeClass("collapse");
        $cache("#txtEmail").val("");
        $cache("#txtEmail").parent().removeClass("has-danger");
    };

    var showResetFormError = function () {
        $cache("#reset-error").addClass("show");
    };

    var showResetFormMsg = function () {
        $cache("#reset-error").removeClass("show");        
        $cache("#txtEmail, #btnReset").addClass("collapse");
        $cache("#reset-msg").addClass("show");
    };

    var resetFormErrorStyles = function () {
        $cache("#txtEmail").parent().addClass("has-danger");
    };


    // Public
    // =======================================
    page.toggleForms = toggleForms;

    page.loginForm = {
        clear: clearLoginForm,
        errorStyles: loginFormErrorStyles,
        showError: showLoginFormError
    };

    page.resetForm = {        
        clear: clearResetForm,
        errorStyles: resetFormErrorStyles,
        showError: showResetFormError,
        showMsg: showResetFormMsg
    };


    return page;
})(page || {});