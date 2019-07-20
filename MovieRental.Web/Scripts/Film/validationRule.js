$.validator.unobtrusive.adapters.add("categoryratingcheck", ["selection"], function (options) {
    options.rules["categoryratingcheck"] = options.params;
    options.messages["categoryratingcheck"] = options.message;

});

$.validator.addMethod("categoryratingcheck", function (value, element, params) {
    var form = $(element).closest('form');
    var selectionValue = $(form).find('select[name=Rating]').val();
    if (value != "0") {
        return true;
    };
    if (selectionValue == "3" || selectionValue == "4") {
        return true;
    };
    return false;
});