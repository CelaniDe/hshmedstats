$('.integer-input').keydown(function (e) {
    var notAllowed = e.keyCode === 69 || e.keyCode === 190 ? true : false;
    if (notAllowed) {
        e.preventDefault();
    }
});

var getReturnUrl = () => {
    let pathName = window.location.pathname;
    if (window.location.search) {
        pathName += window.location.search;
    }
    return pathName;
}

var initializeTagsInput = (element) => {
    $(element).tagsinput(
        {
            tagClass: 'label label-primary'
        }
    );
    $('.bootstrap-tagsinput input').keydown(function (event) {
        if (event.which == 13) {
            $(this).blur();
            $(this).focus();
            return false;
        }
    });
}

var initDate = (element) => {
    $(element).datetimepicker(
        {
            autoclose: true,
            pickDate: false,
            pick12HourFormat: false,
            minView: 2,
            format: 'dd/mm/yyyy',
            dateOnly: true
        }
    );
}

var initYearDate = element => {
    $(element).datetimepicker(
        {
            autoclose: true,
            dateOnly: true,
            format: "yyyy",
            startView: 'decade',
            minView: 'decade',
            viewSelect: 'decade'

        }
    );
}

var initYearMonthDate = element => {
    $('.input-group.date').datetimepicker(
        {
            autoclose: true,
            dateOnly: true,
            format: "mm/yyyy",
            startView: "year",
            minView: "year",
        }
    );
}

var range = (start, end) => {
    return Array(end - start + 1).fill().map((_, idx) => start + idx)
}

var getDateString = (date) => {
    var dd = String(date.getDate()).padStart(2, '0');
    var mm = String(date.getMonth() + 1).padStart(2, '0');
    var yyyy = date.getFullYear();

    return `${dd}/${mm}/${yyyy}`;
}

var formatNumber = (currency, value) => {
    return new Intl.NumberFormat('en-US', { style: 'currency', currency, maximumFractionDigits: 0 }).format(value);
}

var currencyFormat = (pcsEntity, currencyTo, value) => {
    let symbol = pcsEntity === null ? currencyTo === 1 ? 'EUR' : 'GBP' : pcsEntity === 1 ? 'GBP' : 'EUR';
    return formatNumber(symbol, value);
}

var currencyFormatMultipleFields = (pcsEntity, currency, currencyTo, value) => {
    let symbol;
    if (currency === null)
        symbol = pcsEntity === null ? currencyTo === 1 ? 'EUR' : 'GBP' : pcsEntity === 1 ? 'GBP' : 'EUR';
    else
        symbol = currencyTo === 1 ? 'EUR' : 'GBP';
    return formatNumber(symbol, value);
}

var pcsEntityType = (pcsEntity) => {
    let symbol = pcsEntity === null ? 'Both' : pcsEntity === 1 ? 'UK' : 'EU';
    return symbol;
}

var colors = [
    'rgb(255, 99, 132)',
    'rgb(54, 162, 235)',
    'rgb(153, 102, 255)',
    'rgb(220, 190, 35)',
    'rgb(56, 185, 16)',
    'rgb(255, 159, 64)',
    'rgb(255, 51, 255)',
    'rgb(102, 255, 255)',
    'rgb(0, 76, 153)',
    'rgb(153, 76, 0)',
    'rgb(169,169,169)',
]

var transparentColor = color =>
    color.slice(0, color.indexOf(')')) + ',0.2' + color.slice(color.indexOf(')'));

var parseLocaleNumber = (value) => {
    let num = value.substr(1, value.length).replace(/[,.]/g, '');
    return parseInt(num);
}

var loadTabControl = () => {
    if (localStorage.getItem(window.location.pathname)) {
        var el = $('ul.nav a[href="' + localStorage.getItem(window.location.pathname) + '"]');
        el.tab('show');
        el.first().trigger('shown.bs.tab'); //For the tabs that load data on click. 
        localStorage.removeItem(window.location.pathname)
    }

    $(".saveTabToStorage").click((e) => {
        tabControl(e.target.pathname);
    });

    let search = JSON.parse(localStorage.getItem('Search'));

    if (search && search.location === window.location.pathname && search.value) {
        let filter = $('a.active').closest('.tabs-container').find(`${search.tab} [class="dataTables_filter"] [type="search"]`);
        filter.val(search.value);

        let table = $('a.active').closest('.tabs-container').find(`${search.tab}`).find('.table-responsive .dataTables_scrollBody table').DataTable();
        table.search(search.value).draw();
    }
}

function tabControl() {
    if ($('a.active[data-toggle="tab"]').length) {
        localStorage.setItem(window.location.pathname, $('a.active[data-toggle="tab"]')[0].hash);
    }
}

var AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
    return data;
};

$('#side-menu a').click(e => {
    if (JSON.parse(localStorage.getItem('Search')))
        localStorage.setItem('Search', null);
})

const isValidUrl = (url) => {
    try {
        new URL(url);
    } catch (e) {
        return false;
    }
    return true;
};

function base64ToBlob(base64, type = "application/octet-stream") {
    const binStr = atob(base64);
    const len = binStr.length;
    const arr = new Uint8Array(len);
    for (let i = 0; i < len; i++) {
        arr[i] = binStr.charCodeAt(i);
    }
    return new Blob([arr], { type: type });
}

function ConvertTableRows(rows) {

    var result = [];
    for (let i = 0; i < rows.length; i++) {

        var obj = {};
        for (let j = 0; j < rows[i].data.length; j++) {
            obj['column' + j] = rows[i].data[j];
        }
        result.push(obj);
    }

    return result
}

function ConvertTableColumns(columns) {
    var result = [];
    for (let i = 0; i < columns.length; i++) {
        var obj = {};
        obj['data'] = 'column' + i

        obj['title'] = columns[i];

        result.push(obj);
    }

    return result
}

function stringToDate(str) {
    const [dd, mm, yyyy] = str.split('/');
    return new Date(yyyy, mm - 1, dd);
}