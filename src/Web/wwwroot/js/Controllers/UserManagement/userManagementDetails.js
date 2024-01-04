
var UserManagementDetails = (function () {

    var initializeDetails = (model) => {
        $(".chosen-select").chosen({
            "disable_search": true
        });

        Ladda.bind('.ladda-button');
    }

    return {
        init: initializeDetails
    }

})();
