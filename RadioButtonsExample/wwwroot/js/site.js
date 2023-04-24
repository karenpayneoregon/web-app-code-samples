// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//
// Dynamically change active nav item colors
//


document.addEventListener('DOMContentLoaded', () => {

    document.querySelectorAll('.nav-link').forEach(link => {

        link.classList.remove('text-dark');
        link.classList.remove('bg-primary');

        if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
            link.classList.add('text-white');
            link.classList.add('bg-primary');
        } else {
            link.classList.add('text-dark');
        }
    });

})