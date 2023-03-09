$(document).ready(function () {

    var required = $("#select").data("kendoMultiSelect");


    $("#get").click(function () {
        document.getElementById('continentsValues').value = required.value();
    });

});