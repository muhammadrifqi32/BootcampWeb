$(document).ready(function () {
    //$('#supplierTable').DataTable({
    //    "processing": true,
    //    "serverSide": true,
    //    "ajax": LoadSupplier(),
    //    "responsive":true,
    //    "columns": [
    //        { "data": "Name", "autoWidth": true },
    //        { "data": "Email", "autoWidth": true },
    //        { "data": "CreateDate", "autoWidth": true },
    //        {
    //            "data": "Id", "width": "50px", "render": function (data) {
    //                return '<a class="popup" href=/Suppliers/Save/' + data + '">Edit</a>';
    //            }
    //        },
    //        {
    //            "data": "Id", "width": "50px", "render": function (data) {
    //                return '<a class="popup" href=~/suppliers/delete/' + data + '">Delete</a>';
    //            }
    //        }
    //    ]
    //})
    $('#supplierTable').DataTable({
        "order": [],
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }],
        "ajax": LoadSupplier(),
        "responsive": true
    });
    $('.tablecontainer').on('click', 'a.popup', function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    })
    function OpenPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl, function () {
            $('#popupForm', $pageContent).removeData('validator');
            $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
            $.validator.unobtrusive.parse('form');
        });


        $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
                  .html($pageContent)
                  .dialog({
                      draggable: false,
                      autoOpen: false,
                      resizable: false,
                      model: true,
                      title: 'Popup Dialog',
                      height: 550,
                      width: 600,
                      close: function () {
                          $dialog.dialog('destroy').remove();
                      }
                  })

        $('.popupWindow').on('submit', '#popupForm', function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            })

            e.preventDefault();
        })

        $dialog.dialog('open');
    }
})

function LoadSupplier() {
    $.ajax({
        "url": '/suppliers/GetSuppliers',
        "type": "post",
        "datatype": "json"
    }).then((result) => {
        debugger;
    })
}