/**
 *
 * Provides the ability to toggle visibility of all element by classname
 *
 * @param {collection} elements - collection of a specific type
 */
HTMLElement.prototype.toggle = function (elements) {
    for (var index = 0; index < elements.length; index++) {
        if (elements[index].style.display === 'none') {
            elements[index].style.display = 'inline-block';
        }
        else {
            elements[index].style.display = 'none';
        }
    }
}

/**
 *
 * Provides the ability to toggle disabled attribute of all element by classname
 *
 * @param {collection} elements - collection of a specific type
 */
HTMLElement.prototype.disableToggle = function (elements) {
    for (var index = 0; index < elements.length; index++) {
        if (elements[index].disabled === true) {
            elements[index].disabled = false;
        } else {
            elements[index].disabled = true;
        }
    }
}