let Account = (function () {

    function intializeAccountIndex(model) {
        Ladda.bind(".ladda-button");

    }

    $("[type='submit']").click(e => {
        $.get("/Account/PreviewInvoice")
            .done(e => console.log(e))
            .fail(e => console.log(e))
    })

    return {
        init:intializeAccountIndex
    }
})();