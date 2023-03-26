var $ClaimsProgressbar = $ClaimsProgressbar || {};
$ClaimsProgressbar = function () {
    var progressWord = "Progress";

    var init = function (option) {
        
    };

    //
    // Append # to incoming value to ensure it's an
    // identifier
    //
    var assertPoundSymbol = function (value) {

        if (value.charAt(0) !== "#") {
            value = "#" + value;
        }

        return value;
    };

    // Increments or decrements the progress bar on all pages
    var Increment = function (identifier, newValue) {
        var currentValue = parseInt(newValue);

        if (currentValue > 100) {
            progressWord = '';
            currentValue = 0;
        }

        $(assertPoundSymbol(identifier)).css("width", currentValue + "%").attr("aria-valuenow", currentValue).text(currentValue + "% " + progressWord);

        return currentValue;
    };

    var CurrentValue = function (identifier) {
        return parseInt($(identifier).attr("aria-valuenow"));
    };
    //
    // Show progressbar by id e.g.
    //    $ClaimsProgressbar.Show('#progressStatus')
    //
    var Show = function (identifier) {
        $(assertPoundSymbol(identifier)).show();
    };


    //
    // Hide progressbar by id e.g.
    //    $ClaimsProgressbar.Hide('#progressStatus')
    //    
    var Hide = function (identifier) {
        $(assertPoundSymbol(identifier)).hide();
    };

    return {
        init: init,
        CurrentValue: CurrentValue,
        Increment: Increment,
        Show: Show,
        Hide: Hide

    };
}();

