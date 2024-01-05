/*
 * Description: Provides methods for
 *   Determining if a page language is set
 *   Get current page language
 *   Set current page language which is for life span of page
 *
 * Author: Karen Payne
 *
 * Revisions
 * Initial      09/07/2023
 *
 */

var $languageHelper = $languageHelper || {};


$languageHelper = function() {

    const isOtherStyle = ['color: yellow', 'background: blue'].join(';');
    const isEnglishStyle = ['color: white', 'background: red'].join(';');

    function setPageLanguage(code) {

        document.documentElement.setAttribute("lang", code);

        if (code === 'en') {
            console.log('%c%s', isEnglishStyle, `language set to ${code}`);
        } else {
            console.log('%c%s', isOtherStyle, `language set to ${code}`);    
        }
        
    }

    /*
     * Get current page language, recommend first assert using isLanguageSet
     */
    function getPageLanguage() {
        if (document.documentElement.lang) {
            return document.documentElement.lang;
        } else {
            return null;
        }
    }

    /*
     * Check if the current page language is defined
     */
    function isLanguageSet() {
        if (document.documentElement.lang) {
            return true;
        } else {
            return false;
        }        
    }
    return {
        // exposed methods 
        setPageLanguage: setPageLanguage,
        getPageLanguage: getPageLanguage,
        isLanguageSet: isLanguageSet
    };
}();