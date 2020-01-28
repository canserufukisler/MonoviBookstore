var productDT;

$(document).ready(function () {
    //console.log('asd');
    LoadProductDT();
    //console.log('asd222');
});

function LoadProductDT() {
    productDT = $('#tblProduct').DataTable({
        "ajax": {
            "url": "/Administrative/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            { "data": "description", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">

                        <a href="/Administrative/Product/UpdateOrInsert/${data}" class="btn btn-link" style="cursor:pointer">
                            Edit
                        </a>
                        <a onclick=Delete("/Administrative/Product/Delete/${data}") class="btn btn-link" style="cursor:pointer">
                            Delete
                        </a>
                    </div>`;
                }, "width": "20%"
            }
        ]
    });
}


function Delete(url) {
    swal({
        title: "Warning",
        text: "Item will be deleted. Do you want to continue?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((isDelete) => {
        if (isDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        productDT.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });

}