var $Application = $Application || {};
$Application = function () {

    var keyEnabled = true;

    /*
     * @param { settingName } determine if there is a setting in local storage
     */
    var hasStorage = function (settingName) {
        return localStorage.getItem(settingName) !== null;
    };

    /*
     * Setup hot-keys for index page
     * TODO: add logic for different pages e.g. About page should not have a shortcut to itself etc
     */
    var setStandardKeys = function (option) {

        hotkeys('f5', function (event) {
            event.preventDefault();
            alert('you pressed F5!');
        });

        hotkeys('alt+left', function (event) {
            event.preventDefault();
            alert('ALT+Left pressed');
        });

        hotkeys('alt+0', function (event) {
            event.preventDefault();
            $("#skipper").focus();
        });

        hotkeys('alt+a', function (event, handler) {
            event.preventDefault();
            window.location.replace("About");
        });

        hotkeys('ctrl+q', function (event, handler) {
            event.preventDefault();
            $("#btn-submit").focus();
        });


        keyEnabled = true;

    };

    /*
     * Setup hot-keys for about page
     */
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

    /*
     * Setup hot-keys for privacy page
     */
    var setPrivacyPageKeys = function (option) {

        hotkeys('alt+h', function (event, handler) {
            event.preventDefault();
            window.location.replace("Index");
        });

        keyEnabled = true;

    };


    /*
     * remove keys for current page
     */
    var removeKeys = function () {
        hotkeys.deleteScope('all');
        keyEnabled = false;
    };

    /*
     * are hot-keys enabled
     */
    var isEnabled = function () {
        return keyEnabled;
    };

    var supportsLocalStorage = function() {
        if (typeof (Storage) !== "undefined") {
            return true;
        } else {
            return false;
        }
    };

    var saveKeys = function (controlKeys, key) {

        localStorage.setItem("appControlKeys", controlKeys);
        localStorage.setItem("appKey", key);
        return true;
    };

    return {
        removeKeys: removeKeys,
        setKeys: setStandardKeys,
        setAboutPageKeys: setAboutPageKeys,
        setPrivacyPageKeys: setPrivacyPageKeys,
        isEnabled: isEnabled,
        saveKeys: saveKeys,
        supportsLocalStorage: supportsLocalStorage,
        hasStorage: hasStorage
    };
}();