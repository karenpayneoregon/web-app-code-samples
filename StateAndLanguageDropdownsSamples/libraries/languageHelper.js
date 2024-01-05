/*
 * Description: Provides methods for
 *   Determining if a page language is set
 *   Get current page language
 *   Set current page language which is for life span of page
 * Author: Karen Payne
 */

var $languageHelper = $languageHelper || {};


$languageHelper = function () {

    // Pass in a valid language code to set the page language
    function setPageLanguage(code) {
        // case sensitive
        if (code === 'E') {
            code = 'en';            
        }else if (code === 'S') {
            code = 'es';
        }
        document.documentElement.setAttribute('lang', code);
    }

    //Get current page language, recommend first assert using isLanguageSet
    function getPageLanguage() {
        if (document.documentElement.lang) {
            return document.documentElement.lang;
        } else {
            return null;
        }
    }

    //Check if the current page language is defined
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