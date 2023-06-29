var $checkboxHelper = $checkboxHelper || {};
$checkboxHelper = function () {
    /*
     * Pass document.getElementsByClassName("form-check-input")
     */
    var setupCheckboxesClickEvents = function (checkboxes) {
        
        for (let index = 0; index < checkboxes.length; index++) {

            checkboxes[index].onclick = function () {

                if (checkboxes[index].getAttribute('aria-checked') === 'true') {
                    checkboxes[index].setAttribute('aria-checked', 'false');
                } else {
                    checkboxes[index].setAttribute('aria-checked', 'true');
                }

            };
        }
    }

    return {
        initialize: setupCheckboxesClickEvents
    };
}();

