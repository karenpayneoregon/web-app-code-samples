﻿document.addEventListener("DOMContentLoaded", () => {

    $stepOperations.init('groupSteps');
    $stepOperations.unCheckRadioButtons();
    $stepOperations.initializeSteps('#step1', '#option1');
    /**
     * Get current selected radio button being checked
     */
    const select = document.getElementById('stepsContainer');
    select.addEventListener('click', ({ target }) => {
        if (target.getAttribute('name') === $stepOperations.radioGroupName()) {
            $stepOperations.changeSelection(target.value, target.getAttribute('id'));
        }
    });



});