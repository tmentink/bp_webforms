// ===========================================
// Password Validation
// ===========================================

var validation = (function (V) {
    "use strict";

    var defaults = {
        min: 8,
        max: 50,
        number: true,
        lowercase: true,
        uppercase: true
    };

    var getErrors = function (newPassword, confirmPassword, require) {
        var rpv = Resources.passwordValidation;
        var errors = [];

        if (!min(newPassword, require)) {
            errors.push(rpv.MustBeAtLeast + " " + require.min + " " + rpv.CharactersLong);
        }

        if (!max(newPassword, require)) {
            errors.push(rpv.MustBeLessThan + " " + require.max + " " + rpv.CharactersLong);
        }

        if (!number(newPassword, require)) {
            errors.push(rpv.MustContainNumber);
        }

        if (!lowercase(newPassword, require)) {
            errors.push(rpv.MustContainLowercase);
        }

        if (!uppercase(newPassword, require)) {
            errors.push(rpv.MustContainUppercase);
        }

        if (newPassword != confirmPassword) {
            errors.push(rpv.PasswordsDoNotMatch);
        }

        return errors;
    };

    var min = function (password, require) {
        return password.length >= require.min;
    };

    var max = function (password, require) {
        return password.length <= require.max;
    };

    var number = function (password, require) {
        if (require.number) {
            return /\d/.test(password);
        }
        return true;
    };

    var lowercase = function (password, require) {
        if (require.lowercase) {
            return /[a-z]/.test(password);
        }
        return true;
    };

    var uppercase = function (password, require) {
        if (require.uppercase) {
            return /[A-Z]/.test(password);
        }
        return true;
    };

    var validatePassword = function (newPassword, confirmPassword, settings) {        
        var require = $.extend({}, defaults, settings);       
        var errors = getErrors(newPassword, confirmPassword, require);
        var isValid = errors.length == 0;

        return {
            isValid: isValid,
            errors: errors
        };
    };


    // Public
    // =======================================
    V.validatePassword = validatePassword;

    return V;
})(validation || {});
