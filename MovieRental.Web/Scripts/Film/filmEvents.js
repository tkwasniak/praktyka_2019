
$(document).on('click', '.btnUpdateFilm', function () {
    var url = $(this).data("url");
    var id = $(this).data("id");
    getFilmForUpdate(id, url);
});


$(document).on('click', '#btnCloseCreateForm', function () {
    var form = $(this).closest('form');
    clearForm(form);
    $('.acc').foundation('up', $('.accItem'));

});

$(document).on('click', '#btnCreateFilm', function () {

    var url = $(this).data("url");
    var form = $("#createFilmForm");
    form.validate();
    if (form.valid()) {
        createFilm(form, url);
    }
})

$(document).on('click', '#btnCloseUpdateForm', function () {
    $('#updateModal').foundation('close');

});

$(document).on("click", "#btnSaveFilm", function () {
    var url = $(this).data("url");
    var form = $("#editFilmForm");
    form.validate();
    if (form.valid()) {
        updateFilm(form, url);
    }

});

$(document).on('click', '.sortOrder', function () {
    var url = $(this).data('url');
    var target = $(this).data('target');
    if (url) {
        getFilms(url, target);
    }
});

$(document).on('click', '.btnDeleteFilm', function () {
    var title = $(this).data('title');
    var directory = $(this).data('director');
    var id = $(this).data('id');
    var url = $(this).data('url');
    $('#deleteModal p').html(title + ' by ' + directory);
    $('#confirmDeletion').data('id', id);
    $('#confirmDeletion').data('url', url);
    $('#deleteModal').foundation('open');

});

$(document).on('click', '#confirmDeletion', function () {
    var id = $(this).data('id');
    var url = $(this).data('url');
    deleteFilm(id, url);
});


$(document).on('click', '.accordion-title', function () {
    $('.acc').foundation('toggle', $('.accItem'));
});


$(document).on('click', '.pagination a', function (e) {
    e.preventDefault();
    var url = $(this).prop('href');
    if (typeof url === typeof undefined) {
        return;
    }
    var target = $(this).parents('div.pager').data('target'); // rodzicem jest div w ktorym zawarty jest pager
    getFilms(url, target);
});





