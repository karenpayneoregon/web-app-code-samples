var $windowHelpers = $windowHelpers || {};

$windowHelpers = function () {
    var openWind = function (url, popHeight, popWidth) {

        var left = (screen.width / 2) - (popWidth / 2);
        var top = (screen.height / 2) - (popHeight / 2);

        var newWindow = window.open(url, 'name', $`height=${popHeight},width=${popWidth},top=${top},left=${left}`);

        if (window.focus) {
            newWindow.focus();
        }

        return newWindow;

    }

    return {
        openWind: openWind
    };
}();