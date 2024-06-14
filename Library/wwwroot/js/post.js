var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
   dataTable = $('#myTable').DataTable({
        ajax: {
            url: '/admin/post/getall'
        },
        columns: [
            { data: 'title', "width": "25%"  },
            { data: 'category.name', "width": "15%" },
            { data: 'publishDate', "width": "10%"  },
            { data: 'lastEdited', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/post/upsert?id=${data}" class="btn btn-primary mx-2"><i class="fa-solid fa-pencil"></i></a>
                    <a onClick="Delete('/admin/post/delete?id=${data}')" class="btn btn-danger mx-2"><i class="fa-solid fa-trash"></i></a>
                    </div>`
                },
                "width":"15%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    toastr.success(data.message)
                    dataTable.ajax.reload();
                }
            })
        }
    });
}
