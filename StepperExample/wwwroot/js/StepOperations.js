
var $stepOperations = $stepOperations || {};
$stepOperations = function () {

    var groupName = '';


    /**
     * Constructor
     * 
     * @param {string} gbName group name for radio buttons
     */
    var init = function (gbName) {

        groupName = gbName;

    };

    /**
     * Uncheck current selected radio button in group
     */
    var unCheckRadioButtons = function () {
        $(`input[name=${groupName}]:checked`).removeAttr('checked');
    };

    /**
     * Return radio button group name
     */
    var radioGroupName = function () {
        return groupName;
    };

    var removeSteps = function () {
        var all = $('.stepMarker').map(function () {
            return this.id;
        }).get();

        all.forEach(element => {
            $("#" + element).removeClass('btn-primary');
        });
    };


    var initializeSteps = function (currentStep, currentOption) {
        var all = $('.stepMarker').map(function () {
            return this.id;
        }).get();

        all.forEach(element => {
            $(`#${element}`).removeClass('btn-primary');
        });

        $('#step1').addClass('btn-primary');
        $('#option1').prop('checked', true);

        //$(currentStep).addClass('btn-primary');
        //$(currentOption).prop('checked', true);

    };


    /**
     * Perform work on selected radio button on selection change
     * @param {string} name name of radio button
     * @param {string} identifier identifier of radio button
     *
     * For step 5, decide which text to display dependent on a radio button selection
     */
    var changeSelection = function (name, identifier) {

        removeSteps();
        
        $("#" + name).addClass('btn-primary');
        if (name === 'step5') {

            if ($('input[name=userChoice]:checked').attr('id') === 'acceptedOption') {
                document.getElementById('finalResult').innerHTML = 'Accepted';
            } else {
                document.getElementById('finalResult').innerHTML = 'Rejected';
            }
            
        }

        if (name === 'step1') {
            document.getElementById('finalResult').innerHTML = '';
        }
    };

    return {
        init: init,
        initializeSteps: initializeSteps,
        unCheckRadioButtons: unCheckRadioButtons,
        radioGroupName: radioGroupName,
        changeSelection: changeSelection

    };
}();