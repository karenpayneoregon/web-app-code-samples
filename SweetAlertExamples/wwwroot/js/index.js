
function GetIpAddressInput() {
    (async () => {

        const ipAPI = '//api.ipify.org?format=json'

        const inputValue = fetch(ipAPI)
            .then(response => response.json())
            .then(data => data.ip)

        const { value: ipAddress } = await Swal.fire({
            title: 'Enter your IP address',
            input: 'text',
            inputLabel: 'Your IP address',
            inputValue: inputValue,
            showCancelButton: true,
            inputValidator: (value) => {
                if (!value) {
                    return 'You need to write something!'
                }
            }
        })

        if (ipAddress) {
            $("#_ipAddress").val(ipAddress);
            $("#ShowResult2").text(`IP Address is ${ipAddress}`);
        } else {
            $("#_ipAddress").val('Empty');
            $("#ShowResult2").text('');
        }

    })()
}

function GetPassword() {
    (async () => {

        const { value: password } = await Swal.fire({
            title: 'Enter your password',
            input: 'password',
            inputLabel: 'Password',
            inputPlaceholder: 'Enter your password',
            inputAttributes: {
                maxlength: 10,
                autocapitalize: 'off',
                autocorrect: 'off'
            }
        })

        if (password) {
            $("#_password").val(password);
        }

    })()
}

var count = 0;

    function AddProduct() {

        count++;

        $("#ShowResult1").text(count);
    }