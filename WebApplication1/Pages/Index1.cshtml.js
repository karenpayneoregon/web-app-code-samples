document.getElementById("execute").addEventListener("click", function () {
    var snackBar = document.getElementById("snackbar");
    // Dynamically Appending class to HTML element
    snackBar.className = "show-bar";

    setTimeout(function () {
        // Dynamically Removing the Class from HTML element By Replacing it with an Empty String after 5 seconds
        snackBar.className = snackBar.className.replace("show-bar", "");
    }, 5000
    );

});

