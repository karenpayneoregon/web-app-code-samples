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
}


