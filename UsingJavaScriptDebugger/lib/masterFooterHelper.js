var $masterFooterHelper = $masterFooterHelper || {};
$masterFooterHelper = function () {
    /*
     * Create footer
     * Karen created the elements, feed to Chrome Gemini to create the code below
     * https://g.co/gemini/share/0678e34d83f6
     */
    var create = function (href) {
        const footer = document.createElement('footer');
        footer.classList.add('fixed-bottom', 'p-3', 'text-center');
        footer.style.backgroundColor = '#0f506f';

        const span = document.createElement('span');
        span.classList.add('text-white');

        const div = document.createElement('div');
        div.classList.add('footer');

        const link = document.createElement('a');
        link.href = href; // Set the href based on the function parameter
        link.textContent = 'Return to Employment Department Home';

        div.appendChild(link);
        span.appendChild(div);
        footer.appendChild(span);

        return footer;
    }

    return {
        create: create
    };
}();