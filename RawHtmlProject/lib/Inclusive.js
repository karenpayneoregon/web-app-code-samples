(() => {
    'use strict';

    const forms = document.querySelectorAll('.needs-validation');

    Array.from(forms).forEach(form => {
        form.addEventListener('submit',
            event => {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                form.classList.add('was-validated');
            },
            false);
    });
})();

document.getElementById("enableSubmit").addEventListener("click",
    function () {
        document.getElementById("postButton").setAttribute('aria-disabled', false);
        document.getElementById('postButton').disabled = false;
    });

document.getElementById("disableSubmit").addEventListener("click",
    function () {
        document.getElementById("postButton").setAttribute('aria-disabled', true);
        document.getElementById('postButton').disabled = true;
    });

document.getElementById("ResetForm").addEventListener("click",
    function () {
        $('form').get(0).reset();
    });