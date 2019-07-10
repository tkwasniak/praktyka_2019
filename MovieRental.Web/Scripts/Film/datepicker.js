
$('body').on('focus', ".dp", function () {
    var today = new Date();
    $(this).datepicker({
        dateFormat: 'dd.mm.yy',
        maxDate: today,
        minDate: new Date(1950, 1, 1),
        defaultDate: today,
        changeYear: true,
        yearRange: '1950:2019',
        changeMonth: true,
        nextText: '',
        prevText: '',
        defaultDate: today,
        dayNames: ["sds", "", "", "", "", "", ""]
    });
    $('.dp').keydown(function (e) {
        e.preventDefault();
        return false;
    });
})
