"use strict"

class PatientIndex {
    constructor(model) {
        this.viewModel = model;
        this.initUIelements();
    }

    initUIelements() {
        let that = this;
        this.table = new DataTable($("#patient_table"), this.viewModel);
        this.table.init([
            { data: 'id', visible: false },
            { data: 'amka', title: 'Amka' },
            { data: 'fullName', title: 'Full Name' },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return that.table.editButton(`/Patient/Details/${data}`);
                }
            }
        ], null, { order: [[2, "asc"]] })
    }
}

class PatientDetails {
    constructor(model) {
        this.viewModel = model;
        this.initUIElements();
        this.initEvents();
    }

    initUIElements() {
        let that = this;
        $(".chosen-select-search").chosen({
            width: '100%'
        });

        $(".chosen-select").chosen({
            width: '100%'
        });

        initDate($("#VisitDate"));
        initDate($("#BirthDate"));
        initDate($("#DiagnosisDate"));
        initDate($("#TransplantDate"));
        initDate($("#DateOfLastFollowUp"));
        Ladda.bind(".ladda-button");

        this.visitDatatable = new DataTable($("#patient_visit_table"), this.viewModel.patientVisits);
        this.visitDatatable.init([
            { data: 'id', visible: false },
            { data: 'visitDate', title: 'Visit Date' },
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return that.visitDatatable.editButton(`/Patient/VisitDetails/${data}`);
                }
            }
        ], null, { order: [[2, "asc"]] });
    }

    initEvents() {
        $('a[href$=patient_visits]').on('shown.bs.tab', () => this.visitDatatable.adjustColumns());

        $("#DiagnosisType").change((e) => {
            $(".diagnosis").attr("hidden", "hidden");
            let type = $("#DiagnosisType").val();

            if (type === "0") {
                $(".ttp").removeAttr("hidden");
            }
            else if (type === "1") {
                $("#diagnosis_heading").text("HUS");
                $(".hus_stma").removeAttr("hidden");
            }
            else if (type === "2") {
                $("#diagnosis_heading").text("sTMA")
                $(".hus_stma").removeAttr("hidden");
            }
            else if (type === "3") {
                $(".tatma").removeAttr("hidden");
            }
        });
    }
}

class PatientVisitDetails {
    constructor(model) {
        this.viewModel = model;
        this.initUIElements();
        this.initEvents();
    }

    initUIElements() {
        let that = this;
        $(".chosen-select-search").chosen({
            width: '100%'
        });

        $(".chosen-select").chosen({
            width: '100%'
        });
        $(".date").datetimepicker(
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

    initEvents() {
    }
}