
var UserManagement = (function () {

    let usersTable = $('#usersTable');
    var userDataTable = null;
    var initializeIndex = (model) => {
        userDataTable = new DataTable(usersTable, model);
        userDataTable.init([
            { data: 'id', visible: false },
            { data: 'userName', title: 'User Name' },
            { data: 'email', title: 'Email' },
            { data: 'firstName', title: 'First Name' },
            { data: 'lastName', title: 'Last Name' },
            { data: 'role', title: 'User Role' },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    let buttons = `<a class="btn btn-primary ladda-button" data-style="slide-left" href="/UserManagement/Details/${data}">Edit</a>`;
                    if (row.role !== "Administrator")
                        buttons += `<button class="ladda-button btn btn-danger" data-style="slide-left" style="margin-left:5px;" data-id="${data}">Delete</button>`;

                    return buttons;
                }
            }
        ]);
    }

    usersTable.on("click", ".btn-danger", function (e) {
        var id = $(this).data("id");
        //$.post('/UserManagement/Delete', { id: id }).done(function () {

        //});

        $.ajax({
            url: '/UserManagement/Delete/',
            type: "Post",
            data: { id },
            success: function () {
                window.location.reload();
            }
            
        })
    })


    return {
        init: initializeIndex
    }
})();
