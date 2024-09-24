var $urlHelpers = $urlHelpers || {}
$urlHelpers = function () {
    /**
    * Joins multiple URL segments into a single URL.
    * @param {...string} args - The URL segments to join.
    * @returns {string} The joined URL.
    */
    const join = (...args) =>
        args
            .join('/')
            .replace(/[\/]+/g, '/')
            .replace(/^(.+):\//, '$1://')
            .replace(/^file:/, 'file:/')
            .replace(/\/(\?|&|#[^!])/g, '$1')
            .replace(/\?/g, '&')
            .replace('&', '?');

    return {
        joinURL: join
    }
}();
