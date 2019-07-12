$(document).on('click', '.btnDeleteFilm', function () {
    var title = $(this).attr('data-title');
    var release = $(this).attr('data-release');
    var id = $(this).attr('data-id');
    var url = $(this).attr('data-url');
    $('#deleteModal p').html(title + ' ' + release);
    $('#confirmDeletion').attr('data-id', id);
    $('#confirmDeletion').attr('data-url', url);
    $('#deleteModal').foundation('open');

});

$(document).on('click', '.btnUpdateFilm', function () {
    var url = $(this).attr("data-url");
    var id = $(this).attr("data-id");
    getFilmForUpdate(id, url);
});


$(document).on('click', '#btnCloseCreateForm', function () {
    var form = $(this).closest('form');
    clearForm(form);
    $('#acc').foundation('up', $('#accItem'));

});

$(document).on('click', '#btnCreateFilm', function () {
    var url = $(this).attr("data-url");
    var form = $("#createFilmForm");
    form.validate();
    if (form.valid()) {
        createFilm(form, url);
    }
    else {
        //form is not valid
    };
})

$(document).on('click', '#btnCloseUpdateForm', function () {
    $('#updateModal').foundation('close');

});

$(document).on("click", "#btnSaveFilm", function () {
    var url = $(this).attr("data-url");
    var form = $("#editFilmForm");
    form.validate();
    if (form.valid()) {
        updateFilm(form, url);
    }
    else {
        //form is not valid
    };
});

$(document).on('click', '.sortOrder', function () {
    var url = $(this).attr('data-url');
    var target = $(this).attr('data-target');

    if (typeof url === typeof undefined) {
        return;
    }
    getFilms(url, target);
});


$(document).on('click', '#confirmDeletion', function () {
    var id = $(this).attr('data-id');
    var url = $(this).attr('data-url');
    deleteFilm(id, url);
});




$(document).on('click', '#accItemTitle', function () {
    $('#acc').foundation('toggle', $('#accItem'));
});




$(document).on('click', '.pagination a', function (e) {
    e.preventDefault();
    var url = $(this).attr('href');
    if (typeof url === typeof undefined) {
        return;
    }
    var target = $(this).parents('div.pager').attr('data-target'); // rodzicem jest div w ktorym zawarty jest pager
    getFilms(url, target);
});




function displayResultMessage (message) {
    $("#resultMessage p").text(message);
    $('#resultMessage').show();
    setTimeout(function () {

        $("#resultMessage").hide('blind', 5000);
    });
}



function clearForm(form) {
    //reset jQuery Validate's internals
    $(form).find('input[type=text], textarea').val('');

    //for summary
    //$(form).find('[data-valmsg-summary=true]')
    //    .removeClass('validation-summary-valid')
    //    .addClass('validation-summary-valid')
    //    .find('ul').empty();

    //for individual fields
    $(form).find('[data-valmsg-replace]')
        .removeClass('field-validation-error')
        .addClass('field-validation-valid')
        .empty();
};