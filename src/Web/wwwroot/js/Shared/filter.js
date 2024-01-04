var Filter = (function () {
    function init(){
        $('#cancel_filters').click(() => {
            $('#filter_form *').filter(':input').each(function () {
                if ($(this).attr('name') !== '__RequestVerificationToken') {
                    $(this).val("");
                }
            });
            $('#filter_form').submit();
        });

        $('#filter_title_trigger').click(() => { $('#filter_trigger').trigger('click'); });

        $('#filter_trigger').click(() => {
            $(document).ready(() => {
                $(".chosen-select").chosen({
                    width: '100%',
                    multiselect: true
                });
            });
        });
    }
    return {
        init: init
    }
})();