(function ($) {
    $.fn.pcsValidationBuilder = function (model) {
        var that = this;
        var validationFields = that.find('.field-validation');
        if (validationFields) {
            validationFields.each((i, field) => {
                if (model.errors[field.getAttribute('for')]) {
                    var fieldErrors = model.errors[field.getAttribute('for')];
                    field.innerText = fieldErrors.join(', ');
                }
            });
        }
       
    }

    $.fn.pcsValidationCleaner = function () {
        var that = this;
        var validationFields = that.find('.field-validation');
        if (validationFields) {
            validationFields.each((i, field) => {
                field.innerText = "";
            });
        }
    }
})(window.jQuery);