"use strict"

class UserIndex {
    constructor(model) {
        this.viewModel = model;
        this.initUIelements();
    }

    initUIelements() {
        let that = this;
        this.table = new DataTable($("#user_table"), this.viewModel);
        this.table.init([
            { data: 'id', visible: false },
            { data: 'email', title: 'Email' },
            { data: 'firstName', title: 'First Name' },
            { data: 'lastName', title: 'Last Name' },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return that.table.editButton(`/User/Details/${data}`);
                }
            }
        ], null, { order: [[2, "asc"]] })
    }
}

class UserDetails {
    constructor(model) {
        this.viewModel = model;
        this.initUIelements();
    }

    initUIelements() {
        $(".chosen-select").chosen({
            "disable_search": true,
            width: '100%',
        });

        Ladda.bind(".ladda-button");
    }
}