function onClose() {
    $("#showDialogBtn").fadeIn();
}

function onOpen() {
    $("#showDialogBtn").fadeOut();
}

function showDialog() {
    $('#dialog').data("kendoDialog").open();
}

function onSendData() {
    $.ajax({
        url: "/DialogIndex",
        type: "POST",
        data: { custom: "some text" },
        headers: {
            RequestVerificationToken: kendo.antiForgeryTokens().__RequestVerificationToken
        },
        dataType: "json"
    });
}
function onCancelData() {
    $.ajax({
        url: "/DialogIndex",
        type: "POST",
        data: { custom: "cancelled" },
        headers: {
            RequestVerificationToken: kendo.antiForgeryTokens().__RequestVerificationToken
        },
        dataType: "json"
    });
}