function addStyle(element, property, value, important) {

    if (element.style.setProperty) {
        element.style.setProperty(property, '');
    } else {
        element.style.setAttribute(property, '');
    }

    element.setAttribute('style', `${element.style.cssText}${property}:${value}${((important) ? ' !important' : '') + ';'}`);
}


function removeStyle(element, property) {

    if (element.style.removeProperty) {
        element.style.removeProperty(property);
    } else {
        element.style.removeAttribute(property);
    }

    element.setAttribute('style', element.style.cssText.replace(property + ':' + element.style.getPropertyValue(property) + ';', ''));
}

function removeBorder(element) {
    element.style.borderStyle = "none";
    element.style.borderColor = "white";
}

function getElementPropertyValueNormal(element, property) {
    return element.style.getPropertyValue(property);
}

let getElementPropertyValue = (element, property) => element.style.getPropertyValue(property);

