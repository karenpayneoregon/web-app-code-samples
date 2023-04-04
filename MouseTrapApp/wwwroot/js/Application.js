var $Application = $Application || {};
$Application = function () {

    var keyEnabled = false;

    var setKeys = function () {
        Mousetrap.bind(['ctrl+s'], function (e) {
            e.preventDefault();
        });
        keyEnabled = true;
    };

    var removeKeys = function () {
        Mousetrap.unbind(['ctrl+s']);
        keyEnabled = false;
    };

    var isEnabled = function () {
        return keyEnabled;
    };

    return {
        removeKeys: removeKeys,
        setKeys: setKeys,
        isEnabled: isEnabled
    };
}();