var $Application = $Application || {};
$Application = function () {

    var keyEnabled = true;

    var setStandardKeys = function (option) {
        
        hotkeys('f5',  function (event) {
            // Prevent the default refresh event under WINDOWS system
            // does not truly help as there is the refresh button
            event.preventDefault();
            alert('you pressed F5!');
        });

        hotkeys('alt+left',  function (event) {
            event.preventDefault();
            alert('ALT+Left pressed');
        });

        hotkeys('alt+0',  function (event) {
            event.preventDefault();
            alert('ALT+0 pressed');
        });

        hotkeys('alt+a', function (event, handler) {
            event.preventDefault();
            // open about page
            window.location.replace("About");
        });

        hotkeys('ctrl+q', function (event, handler) {
            event.preventDefault();
            // focus submit button with specific identifier
            $("#btn-submit").focus();
        });


        keyEnabled = true;

    };
    var setAboutPageKeys = function (option) {

        hotkeys('f5', function (event) {
            // Prevent the default refresh event under WINDOWS system
            // does not truly help as there is the refresh button
            event.preventDefault();
            alert('you pressed F5!');
        });

        hotkeys('alt+h', function (event, handler) {
            event.preventDefault();
            // open about page
            window.location.replace("Index");
        });

        hotkeys('alt+left', function (event) {
            event.preventDefault();
            alert('ALT+Left pressed');
        });

        hotkeys('alt+0', function (event) {
            event.preventDefault();
            alert('ALT+0 pressed');
        });

        hotkeys('ctrl+q', function (event, handler) {
            event.preventDefault();
            // focus submit button with specific identifier
            $("#btn-submit").focus();
        });


        keyEnabled = true;

    };

    var setPrivacyPageKeys = function (option) {

        hotkeys('alt+h', function (event, handler) {
            event.preventDefault();
            window.location.replace("Index");
        });

        keyEnabled = true;

    };

    var removeKeys = function () {
        hotkeys.deleteScope('all');
        alert('done');
        
        keyEnabled = false;
    };
    var isEnabled = function () {
        return keyEnabled;
    };
    return {
        removeKeys: removeKeys,
        setKeys: setStandardKeys,
        setAboutPageKeys: setAboutPageKeys,
        setPrivacyPageKeys: setPrivacyPageKeys,
        isEnabled: isEnabled
    };
}();