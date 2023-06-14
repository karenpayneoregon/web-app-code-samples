var $documentHelper = $documentHelper || {};
$documentHelper = function () {
    var setDocumentLanguage = function() {
        const urlParams = new URLSearchParams(window.location.search);
        const langValue = urlParams.get('lang');

        if (langValue === 'E') {
            document.documentElement.lang = 'en';
        } else if (langValue === 'E') {
            document.documentElement.lang = 'sp';
        } else {
            document.documentElement.lang = 'en';
        }
    }
    return {
        setDocumentLanguage: setDocumentLanguage
    };
}();