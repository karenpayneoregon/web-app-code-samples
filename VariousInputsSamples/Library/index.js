const hamburgerButton = document.querySelector(".hamburgerButton");
const hamburgerIcon = document.querySelector(".hamburgerIcon");
const nav = document.querySelector(".nav");

window.onload = function () {
    hamburgerButton.classList.add("open");
    hamburgerIcon.classList.add("hamburgerOpen");
    nav.classList.add("navOpen");
}

hamburgerButton.onclick = function () {
    hamburgerButton.classList.toggle("open");
    hamburgerIcon.classList.toggle("hamburgerOpen");
    nav.classList.toggle("navOpen");
}

// Listen to the doc click
window.addEventListener('click', function (e) {
    if (e.target.closest('.sidebar') === null) {
        hamburgerButton.classList.remove("open");
        hamburgerIcon.classList.remove("hamburgerOpen");
        nav.classList.remove("navOpen");
    }
});

window.addEventListener('touchstart', function (e) {
    if (e.target.closest('.sidebar') === null) {
        hamburgerButton.classList.remove("open");
        hamburgerIcon.classList.remove("hamburgerOpen");
        nav.classList.remove("navOpen");
    }
});