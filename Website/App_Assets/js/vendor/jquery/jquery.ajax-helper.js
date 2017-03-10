!function (window) {
    "use strict";

    var errorCallback = {
        done: function () { return this },
        fail: function (fn) { fn(); return this }
    }

    var executeAJAX = function (url, parms, async) {
        if (async === undefined) { async = true; }

        var options = _getOptions(url, parms, async);
        return $.ajax(options);
    }

    // method handles the parsing of json into the desired data type
    // defaults to string if a second parameter isn't supplied
    var processResponse = function (response, dataType) {
        try {
            dataType = dataType || "string";
            dataType = dataType.toLowerCase();

            if (response.d == "") {
                console.log("An empty string was returned. Check the error log for more details.");
                return null;
            }

            switch (dataType) {
                case "string":
                case "html":
                    return response.d;

                case "float":
                    return parseFloat(response.d);

                case "integer":
                case "int":
                    return parseInt(response.d);

                case "boolean":
                case "bool":
                case "bit":
                    if (typeof response.d === "boolean") { return response.d; }
                    if (typeof response.d === "integer") { return (response.d === 1); }

                    return (response.d.toLowerCase() === "true");

                case "datarow":
                case "row":
                case "dr":
                    return $.parseJSON(response.d)[0];

                case "dataset":
                case "ds":
                case "datatable":
                case "table":
                case "dt":
                case "array":
                case "object":
                case "obj":
                    return $.parseJSON(response.d);

                default:
                    console.log("Invalid dataType");
                    return null;
            }
        }
        catch (ex) {
            console.log(ex);
            return null;
        }
    }


    // combines default and user-defined options
    var _getOptions = function (url, parms, async) {
        var defaults = {
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        };

        var options = {
            url: url,
            data: JSON.stringify(parms),
            async: async
        };

        var settings = $.extend({}, defaults, options);

        return settings;
    }


    // Public
    // =================================
    window.AJAXHelper = {
        executeAJAX: executeAJAX,
        processResponse: processResponse,
        errorCallback: errorCallback
    };

}(this);