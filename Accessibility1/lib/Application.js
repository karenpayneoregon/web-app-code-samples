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

    var assignMainContent = function (currentWindow) {
        $(currentWindow).on('keydown',
            function (event) {
                if (event.key === '1' && event.altKey) {
                    $("#firstName").focus();
                }
            });
    };

    var assignFormSubmit = function (currentWindow) {
        $(currentWindow).on('keydown', function (event) {
            if (event.key === 'q' && event.ctrlKey) {
                $("#btn-submit").focus();
            }
        });
    };

    return {
        assignSkipper: assignSkipper,
        assignMainContent: assignMainContent,
        assignFormSubmit: assignFormSubmit
    };

}();