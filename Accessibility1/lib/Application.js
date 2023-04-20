var $Application = $Application || {};
$Application = function () {
    var assignSkipper = function(currentWindow) {
        $(currentWindow).on('keydown',
            function (event) {
                if (event.key === '0' && event.altKey) {
                    $("#skipper").focus();
                }
            });
    };
    return {
        assignSkipper: assignSkipper
    };
}();