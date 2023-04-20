const form = document.querySelector('form');

form.addEventListener('submit', (e) => {

    e.preventDefault();

    const awaitTimeout = delay =>
        new Promise(resolve => setTimeout(resolve, delay));

    awaitTimeout(150).then(() => {
        $("#toast1").toast("show");
    });

    const formData = new FormData(form);

    for (const pair of formData.entries()) {
        if (pair[0] !== "departmentRadioGroup") {

            if (pair[0] === "salary") {
                // only rigged for int at this time
                console.log(`Salary ${parseFloat(pair[1].replaceAll(",", ""))}`);
            } else if (pair[0] === "City") {
                if (pair[1] === "Select") {
                    console.log('No city');
                } else {
                    console.log(pair);
                }
            }
            else {
                console.log(pair);
            }
        }
    }

    console.log(`Is contractor ${$("#contractor").is(":checked") ? 'Yes' : 'No'}`.replace(/ ' /g, " \\' "))

    const checked = form.querySelector('input[name=departmentRadioGroup]:checked');
    if (checked !== null) {
        console.log(`Department '${checked.id}'`.replace(/ ' /g, " \\' "));
    } else {
        console.log('Department not checked');
    }

    

    $('form').get(0).reset();
    
});




var cleaveNumeral = new Cleave('.input-numeral', {
    numeral: true,
    numeralThousandsGroupStyle: 'thousand'
});

document.getElementById("ResetForm").addEventListener("click", function () {
    $('form').get(0).reset();
    document.getElementById("contractor").checked = false;
    document.getElementById("contractor").setAttribute('aria-checked', 'false');
});

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById('city').value = 'Salem';

    document.getElementById("contractor").checked = true;
    document.getElementById("contractor").setAttribute('aria-checked', 'true');

    document.getElementById("sales").checked = true;
    document.getElementById("sales").setAttribute('aria-checked', 'true');
});


document.getElementById("training").addEventListener("click", function (currentIdentifier) {
    handleDepartmentRadioClick(currentIdentifier.target.id);
});

document.getElementById("sales").addEventListener("click", function (currentIdentifier) {
    handleDepartmentRadioClick(currentIdentifier.target.id);
});

document.getElementById("marketing").addEventListener("click", function (currentIdentifier) {
    handleDepartmentRadioClick(currentIdentifier.target.id);
});

document.getElementById("contractor").addEventListener("click", function () {

    if (document.getElementById("contractor").getAttribute('aria-checked') === 'true') {
        document.getElementById("contractor").setAttribute('aria-checked', 'false');
    } else {
        document.getElementById("contractor").setAttribute('aria-checked', 'true');
    }
});

/*
    set all radio buttons aria-checked to false followed by finding the current checked
    radio button and set it checked and set aria-checked to true
*/
const deptRadioButtons = document.getElementsByName("departmentRadioGroup");
function handleDepartmentRadioClick(currentIdentifier) {

    for (var index = 0; index < deptRadioButtons.length; index++) {
        document.getElementById(deptRadioButtons[index].id).setAttribute('aria-checked', 'false');
    }

    for (let index = 0, groups = deptRadioButtons.length; index < groups; index++) {
        if (deptRadioButtons[index].id === currentIdentifier) {
            document.getElementById(currentIdentifier).setAttribute('aria-checked', 'true');
            document.getElementById(currentIdentifier).setAttribute('checked', 'true');
        }
    }
}