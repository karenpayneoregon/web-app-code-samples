$(document).ready(function () {

    var select = function (e) {
        if (e.type != "keypress" || kendo.keys.ENTER == e.keyCode) {
            stepper.select($("#stepIndex").val());
        }

        var stepper = $("#stepper").data("kendoStepper");
    }
})
