function ValidatePhone(phone){
    var errors = phone.getValidationError();
    return getErrorText(errors);
}


function getErrorText(errors) {
    var error = "";
    switch (errors) {
        case 1: // invalid country code
            error = "Invalid country code";
            break;
        case 2: // too short
            error = "Phone number is too short";
            break;
        case 3: // too long
            error = "Phone number is too long";
            break;
        case 4: // not a number
            error = "Please enter valid number";
            break;
        default:
            break;
    }

    return error;
}