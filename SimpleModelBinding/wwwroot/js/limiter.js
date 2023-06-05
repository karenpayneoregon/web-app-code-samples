var $limiter = $limiter || {};
$limiter = function () {
    var input;
    var app;
    var maxLength = 0;

    var init = function(targetInput, liveRegion, allowLength) {
        input = targetInput;
        app = liveRegion;
        maxLength = allowLength;
    }
    var liveRegion = function() {
        return app;
    }
    // when pasted text is too long
    var setErrorForInput = function() {
        app.innerHTML = '<span id="displayMax" class="text-danger">maximum characters exceeded</span>';
    }

    // reset after calling setErrorForInput
    var setNormalForInput = function () {
        app.innerHTML = '<span id="displayMax"></span>';
    }

    // max length for input;
    var allowLength = function() {
        return maxLength;
    }

    var setMaxLength = function (allowLength) {
        maxLength = allowLength;
    }

    // handles paste event for the input element
    var pasteEvent = function (e)  {

        var paste = (e.clipboardData || window.clipboardData).getData('text');

        if (paste.length > allowLength()) {
            e.preventDefault();
            setErrorForInput();
        } else {

            e.target.value = paste;
            setNormalForInput();
            e.preventDefault();
        }

    }

    return {
        init: init,
        liveRegion: liveRegion,
        allowLength: allowLength,
        setMaxLength: setMaxLength,
        setNormalForInput: setNormalForInput,
        setErrorForInput: setErrorForInput,
        pasteEvent: pasteEvent
    };
}();