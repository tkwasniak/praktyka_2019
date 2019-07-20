$(document).ready(function (e) {
    setDatepicker();
})
function setDatepicker() {
    var today = new Date();
    $('.dp').datepicker({
        dateFormat: 'dd-M-yy',
         maxDate: today,
         minDate: new Date(1950, 1, 1),
         defaultDate: today,
         changeYear: true,
         yearRange: '1950:2019',
         changeMonth: true,
         nextText: '',
         prevText: '',
         defaultDate: today,
    });
    $('.dp').keydown(function (e) {
        e.preventDefault();
        return false;
    });
};
