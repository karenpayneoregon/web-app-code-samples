$('form').submit(function (e) {
    document.getElementById("sugarCheckedValue").value = document.getElementById("addSugar").ariaChecked;
    document.getElementById("cremeCheckedValue").value = document.getElementById("addCreme").checked;
    document.getElementById("foot").innerHTML =
        `Add sugar <strong>ariaChecked</strong> <span class="text-danger fw-bold">${document.getElementById("addSugar").ariaChecked}</span>
                   <strong>checked</strong> <span class="text-danger fw-bold">${document.getElementById("addSugar").checked}</span>`;

    e.preventDefault();
});
var checkboxes = document.getElementsByClassName("form-check-input");

// setup logic to toggle aria-checked
for (let index = 0; index < checkboxes.length; index++) {

    checkboxes[index].onclick = function () {

        if (checkboxes[index].getAttribute('aria-checked') === 'true') {
            checkboxes[index].setAttribute('aria-checked', 'false');
        } else {
            checkboxes[index].setAttribute('aria-checked', 'true');
        }
    };
}