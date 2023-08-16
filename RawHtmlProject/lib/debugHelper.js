var $debugHelper = $debugHelper || {};
$debugHelper = function () {

    /*
     * Add/remove debugger.css to the current page
     */

    var href = "lib/debugger.css";
    var addCss = function () {
        if (styleStyleIsLoaded(href) === true) {
            return;
        }
        var head = document.head;
        var link = document.createElement("link");

        link.type = "text/css";
        link.rel = "stylesheet";
        link.href = href;

        head.appendChild(link);
    };

    var removeCss = function () {

        if (styleStyleIsLoaded('debugger.css')) {
            document.querySelector(`link[href$="${href}"]`).remove();
        }
        
    };

    var toggle = function() {
        if (styleStyleIsLoaded(href) === true) {
            removeCss();
        } else {
            addCss();
        }
    }

    /*
     * Determine if the style sheet is loaded in the pages
     */
    var styleStyleIsLoaded = function () {

        for (var index = 0, count = document.styleSheets.length; index < count; index++) {
            var sheet = document.styleSheets[index];

            if (!sheet.href) {
                continue;
            }

            if (sheet.href.includes(href)) {
                return true;
            }

        }

        return false;
    }

    return {
        addCss: addCss,
        removeCss: removeCss,
        isCSSLinkLoaded: styleStyleIsLoaded,
        toggle: toggle
    };
}();