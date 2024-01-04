jQuery.fn.extend({
    hideElement: function () {
        return this.each(function () {
            this.setAttribute("hidden", "hidden");
        });
    },
    showElement: function () {
        return this.each(function () {
            this.removeAttribute("hidden");
        });
    },
    disableElement: function () {
        return this.each(function () {
            this.setAttribute("disabled", "disabled");
        });
    },

    enableElement: function () {
        return this.each(function () {
            this.removeAttribute("disabled");
        });
    },
    readonly: function () {
        return this.each(function () {
            this.setAttribute("readonly", "readonly");
        });
    },
    editable: function () {
        return this.each(function () {
            this.removeAttribute("readonly");
        });
    },
    check: function () {
        return this.each(function () {
            this.checked = true;
        });
    },
    uncheck: function () {
        return this.each(function () {
            this.checked = false;
        });
    },
    showModal: function () {
        return this.each(function () {
            $(this).modal('show')
        });
    },
    hideModal: function () {
        return this.each(function () {
            $(this).modal('hide')
        });
    },
    triggerChosen: function () {
        return this.each(function () {
            $(this).trigger('chosen:updated')
        });
    }
});


