var $debugHelper = $debugHelper || {};
$debugHelper = function () {

    /*
     * Add/remove debugger.css to the current page
     */

    var href = "lib/debugger.css";
    var addCss = function () {
        if (isCssLoaded(href) === true) {
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

        if (isCssLoaded('debugger.css')) {
            document.querySelector(`link[href$="${href}"]`).remove();
        }
        
    };

    var toggle = function() {
        if (isCssLoaded(href) === true) {
            removeCss();
        } else {
            addCss();
        }
    }

    var isCssLoaded = function () {

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
        isCSSLinkLoaded: isCssLoaded,
        toggle: toggle
    };
}();