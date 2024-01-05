// Accepts the hyphenated versions (i.e. not 'cssFloat')
// https://stackoverflow.com/a/19171469/5509738
function addStyle(element, property, value, important) {
    // Remove previously defined property
    if (element.style.setProperty)
        element.style.setProperty(property, '');
    else
        element.style.setAttribute(property, '');

    // Insert the new style with all the old rules
    element.setAttribute('style', element.style.cssText + property + ':' + value + ((important) ? ' !important' : '') + ';');
}