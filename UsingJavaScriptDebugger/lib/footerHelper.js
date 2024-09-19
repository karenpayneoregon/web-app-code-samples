/*
 * The following, creates an instance of the class as needed
 * or uses the existing instance if it already exists.
 *
 * In most cases, the module pattern is the best way to create a singleton.
 */
var $footerHelper = $footerHelper || {};
$footerHelper = function () {
    /*
     * Create footer 
     * @param {string} href - URL
     * @param {string} location - URL from page
     * @param {string} lang - language
     */
    const create = function (href, location, lang = 'e') {

        const footer = document.createElement('footer');
        footer.classList.add('fixed-bottom', 'p-3', 'text-center');
        footer.style.backgroundColor = '#0f506f';

        const span = document.createElement('span');
        span.classList.add('text-white');

        const div = document.createElement('div');
        div.classList.add('footer');

        const link = document.createElement('a');
        link.href = `${href}${location}`;

        if (lang === 'e') {
            link.textContent = 'Return to Employment Department Home';    
        } else if (lang === 's') {
            link.textContent = 'Regresar a la p&aacute;gina de inicio del Departamento de Empleo';
        } 
        

        div.appendChild(link);
        span.appendChild(div);
        footer.appendChild(span);

        return footer;
    };

    // Exposed API
    return { create: create };

}();
