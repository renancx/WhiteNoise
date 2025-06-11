$(document).ready(function () {
    $('.datatable').DataTable({
        language: {
            lengthMenu: "<div class='d-flex flex-wrap align-items-center'>" +
                "<div class='me-2'>_MENU_ </div>" +
                "<div class='ml-2'>registros por página</div>" +
                "</div>",
            info: "Mostrando _START_ até _END_ (_TOTAL_ itens)",
            infoEmpty: "Mostrando 0 até 0 de 0 itens",
            infoFiltered: "",
            zeroRecords: "Nenhum registro encontrado",
            search: "",
            searchPlaceholder: "Buscar...",
            paginate: {
                first: '<i class="bi bi-chevron-double-left"></i>',
                previous: '<i class="bi bi-chevron-left"></i>',
                next: '<i class="bi bi-chevron-right"></i>',
                last: '<i class="bi bi-chevron-double-right"></i>'
            }
        },
        lengthMenu: [10, 25, 50, 100],
        pageLength: 10,
        initComplete: function () {
            $('.dataTables_filter label').contents().filter(function () {
                return this.nodeType === 3;
            }).remove();
        }
    });
});