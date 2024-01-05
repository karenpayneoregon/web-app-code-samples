

function addStyle(element, property, value, important) {

    if (element.style.setProperty) {
        element.style.setProperty(property, '');
    } else {
        element.style.setAttribute(property, '');
    }

    //element.setAttribute('style', element.style.cssText + property + ':' + value + ((important) ? ' !important' : '') + ';');

    element.setAttribute('style', `${element.style.cssText + property}:${value}${((important) ? ' !important' : '') + ';'}`);
}