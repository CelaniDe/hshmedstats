class DataTable {
    constructor(table, data) {
        this.table = table;
        this.data = data;
        this.datatable = null;
        this.defaultOptions = {
            order: [[0, "asc"]],
            paging: true,
            info: true,
            searching: true,
            buttons: [],
            dom: '<"table-html-buttons"B>lTfgitp',
            pageLength:25
        };
    }

    init(columns, rowCallback, tableOptions = {}) {
        let that = this;
        var options = this.defaultOptions;
        Object.assign(options, tableOptions);

        if (tableOptions.isReport) {
            options.dom = '<"report-html-buttons"B>lTfgitp'
        }

        //Default button column width.
        if (columns.length > 0) {
            columns[columns.length - 1].width = "12%";
        }

        if (this.table) {
            var datatable = {
                data: this.data,
                columns: columns,
                select: {
                    'style': 'multi'
                },
                pageLength: options.pageLength,
                scrollX: true,
                rowId: 'id',
                rowCallback: rowCallback ? rowCallback : function () { },
                drawCallback: function () {
                    if (Ladda) {
                        Ladda.bind(".ladda-button");
                    }
                }
            };
            Object.assign(datatable, options);
            if (options.footerCallback) {
                let columnElement = "";
                columns.forEach((col) => { columnElement += '<th></th>' });
                this.table.append(`<tfoot><tr>${columnElement}</tr></tfoot>`);
            }
            
            this.datatable = this.table.DataTable(datatable);

            this.datatable.columns.adjust();
            
        }

        $('.dt-buttons').removeClass("btn-group");

        $(".dataTables_scrollBody").mousemove(function (e) {
            let documentWidth = $(document).width();
            let scrollBody = document.querySelector(".dataTables_scrollBody");
            let scrollStartPosition = {
                right: documentWidth - 200,
                left: 400
            };

            if (documentWidth < 1400) {
                scrollStartPosition.left = 500;
            }

            if (scrollBody) {
                if (e.pageX > scrollStartPosition.right) {
                    scrollBody.scrollLeft += 15
                } else if (e.pageX < scrollStartPosition.left) {
                    scrollBody.scrollLeft -= 15
                }
            }
        });

        let filter = this.table[0].id + '_filter';
        let search = null;

        $(`#${filter} [type="search"]`).change(e => {
            search = {
                value: e.target.value,
                location: window.location.pathname
            }

            if ($('a.active[data-toggle="tab"]').length) {
                Object.assign(search, { tab: $('a.active[data-toggle="tab"]')[0].hash });
            }

            localStorage.setItem('Search', JSON.stringify(search))
        })

        if (!$('.nav.nav-tabs').length) {
            let search = JSON.parse(localStorage.getItem('Search'))
            if (search && search.location === window.location.pathname && search.value) {
                $(`#${filter} [type="search"]`).val(search.value);
                this.datatable.search(search.value).draw();
            }
        }
    }

    adjustColumns() {
        this.datatable.columns.adjust();
    }


    editButton(href, name = "Edit") {
        return `<a class="btn btn-primary ladda-button" data-style="slide-left" href="${href}">${name}</a>`;
    }

    customButton(href, name, className = "") {
        return `<button class="btn btn-primary ladda-button ${className}" data-style="slide-left">${name}</button>`;
    }

    downloadButton(href, innerText) {
        return `<a class="btn btn-primary" target="_blank"href="${href}">${innerText}</a>`;
    }

    getSelectedIds() {
        let selected = this.datatable.column(0).checkboxes.selected();
        let data = this.datatable.rows().data().filter(d => Array.from(selected).includes(d.id));
        let ids = Array.from(data.map(r => r.id));
        return ids;
    }

    createColumnLink(controller, action, routeValues, displayData, returnUrl, classes = "",openInNewTab = false) {
        let href = `/${controller}/${action}?`;
        for (const [key, value] of Object.entries(routeValues)) {
            href += `${key}=${value}&`
        }
        if (returnUrl) {
            href += `returnUrl=${returnUrl}`
        }
        if (openInNewTab)
            return `<a class="${classes}" target="_blank" href="${href}">${displayData}</a>`;
        return `<a class="${classes}" href="${href}">${displayData}</a>`;
        
    }

    sortAndRenderDate(data, type) {
        if (data === null) {
            return null;
        }
            
        if (type === "sort") {
            return new Date(data).getTime();
        }

        var tempDate = new Date(data);
        return getDateString(tempDate);
    }

    redrawDatatable(data) {
        this.datatable.clear().draw();
        this.datatable.rows.add(data).draw();
        this.datatable.columns.adjust();
    }

    addNewRow(data) {
        this.datatable.row.add(data).draw();
    }

    addNewRowList(data) {
        data.forEach(d => this.datatable.row.add(d).draw());
    }

    removeRow(rowIx) {
        this.datatable.row(rowIx).remove().draw();
    }
    destroyDatatable() {
        this.datatable.destroy();
    }
}