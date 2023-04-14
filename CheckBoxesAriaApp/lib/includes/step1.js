$(document).ready(function (e) {
    $("#SSN").blur(function () {
    	
        var ssnValue = $(this).val();

        $.ajax(
        {
                url: "dataOperations.cfc?method=getPinFileJSON&returnformat=json", data: "ssn=" + ssnValue
        })
            .done(function (data) {
                if (data === '"NEW"') {
                    $('#newPinDiv').show();
                    $('#headAlert').slideDown(1000);
                }
            })
            .fail(function (jqHXR, status, error) {
                $('#results').html("<p>Sorry! Something's wrong...<br /> Error: " + status + "</p>");
            });
    });
});