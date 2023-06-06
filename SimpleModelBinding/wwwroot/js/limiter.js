var $limiter = $limiter || {};
$limiter = function () {
    var input;
    var app;
    var maxLength = 0;
    // set to true when pasting too much from the clipboard
    var hadToTruncate = false;
    var browserAppName = navigator.appName;

    var init = function(targetInput, liveRegion, allowLength) {
        input = targetInput;
        app = liveRegion;
        maxLength = allowLength;

        // aria-live output
        //The input event fires every time whenever the value of the <input> element changes.
        input.addEventListener('input', function () {

            if (hadToTruncate === true) {
                $limiter.setErrorForInput();
                hadToTruncate = false;
                return;
            } else {
                $limiter.liveRegion().textContent = '';
                return;
            }

        }, false);

    }
    var liveRegion = function() {
        return app;
    }
    // when pasted text is too long
    var setErrorForInput = function() {
        app.innerHTML = '<span id="displayMax" class="text-danger">maximum characters exceeded</span>';
    }

    // reset after calling setErrorForInput
    var setNormalForInput = function () { app.innerHTML = '<span id="displayMax"></span>'; }

    // max length for input;
    var allowLength = function() { return maxLength; }

    var setMaxLength = function (allowLength) { maxLength = allowLength; }

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
    // monitor text limit for the input
    var watchLimit = function() {
        if (input.value.length === allowLength()) return false;
        return true;
    }

    var watchCount = function (sender, counter) {
        var counterContainer = eval(`document.all.${counter}`);
        var value = sender.value;

        if (value.length > allowLength()) value = value.substring(0, allowLength());
        if (counterContainer) {
            if (browserAppName === "Netscape") {
                counterContainer.textContent = allowLength() - value.length;
            } else {
                counterContainer.innerText = allowLength() - value.length;
            }
        }

        return true;

    }
    var about = function() {
        let firstName = 'Karen',
            lastName = 'Payne',
            version = '1.0.0.0';

        return { 'Created by': `${firstName} ${lastName}`, 'Version': version };

    }
    return {
        init: init,
        about: about,
        liveRegion: liveRegion,
        allowLength: allowLength,
        setMaxLength: setMaxLength,
        setNormalForInput: setNormalForInput,
        setErrorForInput: setErrorForInput,
        pasteEvent: pasteEvent,
        watchLimit: watchLimit,
        watchCount: watchCount
    };
}();