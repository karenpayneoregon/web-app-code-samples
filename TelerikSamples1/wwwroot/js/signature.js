$(document).ready(function () {
    var signature = $("#signature").getKendoSignature();

    $("#toolbar").kendoToolBar({
        items: [
            {
                template: "<label>Brush:</label><input id='colorpicker'/>",
                id: "brush",
                overflow: "never"
            },
            {
                type: "splitButton",
                text: "Size",
                id: "sizes",
                overflow: "never",
                menuButtons: [
                    { text: "Normal" },
                    { text: "Wide" }
                ],
                click: function (e) {
                    signature.setOptions({
                        strokeWidth: e.target.text() === "Wide" ? 3 : 1
                    });
                }
            },
            {
                template: "<label>Background:</label><input id='background'/>",
                id: "bccolor",
                overflow: "never"
            }
        ]
    });

    $("#bottomtoolbar").kendoToolBar({
        items: [
            {
                type: "button",
                text: "Save",
                primary: true,
                icon: "save",
                click: function () {
                    kendo.saveAs({
                        dataURI: signature.value(),
                        fileName: "signature.png"
                    });
                }
            },
            {
                type: "button",
                text: "Clear",
                click: function () {
                    signature.reset();
                }
            }
        ]
    });

    $("#colorpicker").kendoColorPicker({
        view: "gradient",
        views: ["gradient", "palette"],
        value: "#000000",
        change: function (e) {
            signature.setOptions({
                color: e.value
            });
        },
        buttons: false
    });

    $("#background").kendoColorPicker({
        view: "gradient",
        views: ["gradient", "palette"],
        value: "#FFFFFF",
        change: function (e) {
            signature.setOptions({
                backgroundColor: e.value
            });
        },
        buttons: false
    });
});