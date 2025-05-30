//arquivo grid-sort.js

$(function () {
    $(".table-sorter").tablesorter({
        theme: 'bootstrap_4',
        headerTemplate: '{content} {icon}',
        widgets: ['zebra']
    });
});
