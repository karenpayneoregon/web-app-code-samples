var $languageHelper = $languageHelper || {};
$languageHelper = function() {

    function setPageLanguage(code) {
        document.documentElement.setAttribute("lang", code);
    }

    function getPageLanguage() {
        if (document.documentElement.lang) {
            return document.documentElement.lang;
        } else {
            return null;
        }
    }

    function isLanguageSet() {
        if (document.documentElement.lang) {
            return true;
        } else {
            return false;
        }        
    }
    return {
        setPageLanguage: setPageLanguage,
        getPageLanguage: getPageLanguage,
        isLanguageSet: isLanguageSet
    };
}();