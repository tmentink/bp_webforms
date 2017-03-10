
module.exports = function (grunt) {
    var files = grunt.file.readJSON("gruntConfig.json")

    grunt.initConfig({
        pkg: grunt.file.readJSON("package.json"),
        clean: {
            contents: ["App_Assets/temp"]
        },
        sass: {
            options: {
                outputStyle: "expanded"
            },
            singleDEV: {
                files: [
                    {
                        src: "App_Assets/scss/pages/" + files.single + "/master.scss",
                        dest: "css/" + files.single + ".min.css"
                    }
                ],
            },
            singlePRD: {
                options: {
                    outputStyle: "compressed"
                },
                files: [
                    {
                        src: "App_Assets/scss/pages/" + files.single + "/master.scss",
                        dest: "css/" + files.single + ".min.css"
                    }
                ],
            },
            groupDEV: {
                files: [
                    {
                        expand: true,
                        cwd: "App_Assets/scss/pages/",
                        src: ["**/master.scss"],
                        dest: "css/",
                        filter: function (path) {
                            var fileName = path.slice(22, -12);
                            return files.group.includes(fileName);
                        },
                        rename: function (dest, src) {
                            return dest + src.substring(0, src.indexOf("/")) + ".min.css"
                        }
                    },
                ]
            },
            groupPRD: {
                options: {
                    outputStyle: "compressed"
                },
                files: [
                    {
                        expand: true,
                        cwd: "App_Assets/scss/pages/",
                        src: ["**/master.scss"],
                        dest: "css/",
                        filter: function (path) {
                            var fileName = path.slice(22, -12);
                            return files.group.includes(fileName);
                        },
                        rename: function (dest, src) {
                            return dest + src.substring(0, src.indexOf("/")) + ".min.css"
                        }
                    },
                ]
            },
        },
        uglify: {
            DEV: {
                options: {
                    beautify: {
                        beautify: true,
                    },
                    mangle: false,
                    compress: false,
                    preserveComments: "all"
                },
                files: [
                    {
                        expand: true,
                        cwd: "App_Assets/temp/",
                        src: ["*.js"],
                        dest: "js/",
                        ext: ".min.js",
                        extDot: "last",
                        flatten: true
                    },
                ],
            },
            PRD: {
                files: [
                    {
                        expand: true,
                        cwd: "App_Assets/temp/",
                        src: ["*.js"],
                        dest: "js/",
                        ext: ".min.js",
                        extDot: "last",
                        flatten: true
                    },
                ],
            }
        },
        watch: {
            js: {
                files: ["App_Assets/js/**/*.js", "App_Assets/ajax/**/*.js"],
                tasks: ["singleConcat", "concat", "uglify:DEV"]
            },
            css: {
                files: ["App_Assets/scss/**/*.scss"],
                tasks: ["sass:singleDEV"]
            }
        }
    });

    require('load-grunt-tasks')(grunt);

    grunt.registerTask("singleConcat", "run concat for file", function () {
        var concat = {};
        concat[files.single] = {
            src: grunt.file.readJSON("App_Assets/js/pages/" + files.single + "/master.json").src,
            dest: "App_Assets/temp/" + files.single + '.js'
        }
        grunt.config.set('concat', concat);
    });
    grunt.registerTask("groupConcat", "run concat for each file in group", function () {
        grunt.file.expand("App_Assets/js/pages/*").forEach(function (dir) {
            var concat = grunt.config.get('concat') || {};
            var fileName = dir.substr(dir.lastIndexOf('/') + 1);
            if (files.group.includes(fileName)) {
                concat[fileName] = {
                    src: grunt.file.readJSON("App_Assets/js/pages/" + fileName + "/master.json").src,
                    dest: "App_Assets/temp/" + fileName + '.js'
                };
            }
            grunt.config.set('concat', concat);
        });
    });

    grunt.registerTask("default", ["singleConcat", "concat", "uglify:DEV", "sass:singleDEV", "clean"]);
    grunt.registerTask("prd", ["singleConcat", "concat", "uglify:PRD", "sass:singlePRD", "clean"]);

    grunt.registerTask("group", ["groupConcat", "concat", "uglify:DEV", "sass:groupDEV", "clean"]);
    grunt.registerTask("group-prd", ["groupConcat", "concat", "uglify:PRD", "sass:groupPRD", "clean"]);
};