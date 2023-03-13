
/*
 * DO NOT copy-n-paste as there is form specific code here
 */

var $SweetDialogs = $SweetDialogs || {};
$SweetDialogs = function () {
    var ThreeButtonQuestion = function () {
        GetConfirmationThreeButtons();
    };

    var TwoButtonQuestion = function () {
        GetConfirmation();
    };

    function GetConfirmationThreeButtons() {
        (async () => {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    denyButton: 'btn btn-primary',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: 'Do you want to save the changes?',
                showDenyButton: true,
                showCancelButton: true,
                confirmButtonText: 'Save',
                denyButtonText: `Don't save`,
                allowOutsideClick: false,
            }).then((result) => {
                if (result.isConfirmed) {
                    //Swal.fire('Saved!', '', 'success')
                    $("#_confirmation1").val(1);
                    document.getElementById("_resultItem").setAttribute('value', 'Confirmed');
                    document.getElementById("form1").submit();
                } else if (result.isDenied) {
                    //Swal.fire('Changes are not saved', '', 'info')
                    $("#_confirmation1").val(2);
                    document.getElementById("_resultItem").setAttribute('value', 'Denied');
                    document.getElementById("form1").submit();
                } else {
                    $("#_confirmation1").val(3);
                    document.getElementById("_resultItem").setAttribute('value', 'Nada');
                    document.getElementById("form1").submit();
                }
            })
        })()
    };
    function GetConfirmation() {
        (async () => {

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-danger',
                    cancelButton: 'btn btn-primary'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: 'Are you sure?',
                html: "You <strong>won't</strong> be able to revert this!",
                //icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!',
                cancelButtonText: 'No, cancel!',
                allowOutsideClick: false,
            }).then((result) => {
                if (result.isConfirmed) {
                    $("#_confirmation").val(true);
                    document.getElementById("form1").submit();
                } else if (result.isDismissed) {
                    $("#_confirmation").val(false);
                    document.getElementById("form1").submit();
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    $("#_confirmation").val(false);                    
                    document.getElementById("form1").submit();
                }
            })
        })()
    };
    return {
        ThreeButtonQuestion: ThreeButtonQuestion,
        TwoButtonQuestion: TwoButtonQuestion
    };
}();