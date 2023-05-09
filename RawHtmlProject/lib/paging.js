$('#pagination-demo').twbsPagination({
    totalPages: 5,
    // the current page that show on start
    startPage: 1,

    // maximum visible pages
    visiblePages: 5,

    initiateStartPageClick: true,

    // template for pagination links
    href: false,

    // variable name in href template for page number
    hrefVariable: '{{number}}',

    // Text labels
    first: 'First',
    prev: 'Previous',
    next: 'Next',
    last: 'Last',

    // carousel-style pagination
    loop: false,

    // callback function
    onPageClick: function (event, page) {
        $('.page-active').removeClass('page-active');
        $('#page' + page).addClass('page-active');
    },

    // pagination Classes
    paginationClass: 'pagination',
    nextClass: 'next',
    prevClass: 'prev',
    lastClass: 'last',
    firstClass: 'first',
    pageClass: 'page',
    activeClass: 'active',
    disabledClass: 'disabled'

});