document.addEventListener('DOMContentLoaded', () => {

    document.querySelectorAll('.nav-link').forEach(link => {

        link.classList.remove('border-bottom');
        link.classList.remove('border-top');

        if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
            link.classList.add('border-success');
            link.classList.add('border-bottom');
            link.classList.add('border-top');
        } else {
            link.classList.add('text-success');
        }
    });
    // for displaying client size for development environment
    if ($('#app-footer-span').length > 0) {
        window.addEventListener("resize", displayWindowSizeForDevelopment);
        displayWindowSizeForDevelopment();
    }
});

document.addEventListener('keydown', function (event) {

    if (event.key === '1' && event.altKey && event.ctrlKey) {
        $debugHelper.toggle();
    }

});
function displayWindowSizeForDevelopment() {
    const width = document.documentElement.clientWidth;
    const height = document.documentElement.clientHeight;

    document.getElementById("app-footer-span").innerHTML =
        `<strong>Width:</strong> ${width}, <strong>Height:</strong> ${height}`;
}