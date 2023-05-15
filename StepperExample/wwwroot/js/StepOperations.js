'use strict';

var $stepOperations = $stepOperations || {};
$stepOperations = function () {

    var radioGroupName = "";


    /**
     * Constructor
     * 
     * @param {string} gbName group name for radio buttons
     */
    var init = function (gbName) {

        radioGroupName = gbName;

    };

    /**
     * Uncheck current selected radio button in group
     */
    var unCheckRadioButtons = function () {

        $(`input[name=${radioGroupName}]:checked`).removeAttr('checked');

    };

    /**
     * Return radio button group name
     */
    var radioGroupName = function () {
        return radioGroupName;
    }

    var removeSteps = function () {
        var all = $(".stepMarker").map(function () {
            return this.id
        }).get();

        all.forEach(element => {
            $("#" + element).removeClass("btn-primary")
        });
    }

    var removeAlerts = function (params) {
        $('#defaultAlert').remove();
        $('#A1').remove();
        $('#A2').remove();
        $('#A3').remove();

    }

    var initializeSteps = function () {
        var all = $(".stepMarker").map(function () {
            return this.id
        }).get();

        all.forEach(element => {
            $(`#${element}`).removeClass("btn-primary")
        });

        $("#step1").addClass("btn-primary")
        $("#option1").prop("checked", true);

    }

    var maximumSteps = 7;
    var calculate = function () {

        var iterations = 100; 
        for (var i = 1; i <= iterations; i++) {

            if (iterations % i === 10) {
                console.log(i);
            }
        }
        var outOff = 100;
        var value = 10;
        var result = (value * 100) / outOff;
        return result;
    }


    /**
     * Perform work on selected radio button on selection change
     * @param {string} name name of radio button
     * @param {string} identifier identifier of radio button
     */
    var changeSelection = function (name, identifier) {
        removeSteps();
        
        $("#" + name).addClass("btn-primary");
        if (name === 'step5') {
            document.getElementById('finalResult').innerHTML = 'Accepted';
        }

        if (name === 'step1') {
            document.getElementById('finalResult').innerHTML = '';
        }
    }

    /**
     * Declare publicly scoped methods and properties
     */
    return {
        init: init,
        initializeSteps: initializeSteps,
        unCheckRadioButtons: unCheckRadioButtons,
        radioGroupName: radioGroupName,
        changeSelection: changeSelection,
        removeAlerts: removeAlerts,
        calculate: calculate

    };
}();