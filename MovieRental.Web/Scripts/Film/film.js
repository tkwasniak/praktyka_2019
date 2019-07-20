function getFilms(url, target) {
    $.ajax({
        url: url,
        method: 'get',
        cache: 'false',
        success: function (data) {
            $(target).replaceWith(data);
        },
        error: function (result) {
            $('#errorDisplayModal p').html(result);
            $('#errorDisplayModal').foundation('open');
        }
    });
}

function createFilm(form, url) {
    $.ajax({
        url: url,
        method: 'post',
        data: form.serialize(),
        success: function (result) {
            if (result.HasSucceeded === true) {
                form.trigger("reset");
                var url = $('.current a').prop('href');
                getFilms(url, "#tableWrapper");
                displayResultMessage("Movie successfully added!");
            }
            else {
                $('#errorDisplayModal p').html(result.Errors);
                $('#errorDisplayModal').foundation('open');
            }
        },
        error: function (result) {
            $('#errorDisplayModal p').html(result);
            $('#errorDisplayModal').foundation('open');
        }
    });
}


function getFilmForUpdate(id, url) {
    $.ajax({
        url: url,
        method: 'get',
        data: { 'id': id },
        success: function (result) {
            if (result.response.HasSucceeded) {
                // putting partial view containing the form into the modal
                var form = $("#updateFormWrapper").html(result.view);
                setDatepicker();
                $('#updateFormWrapper').removeData('validator').removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse(form);
                $('#updateModal').foundation('open');

            }
            else {
                $('#errorDisplayModal p').html(result.Errors);
                $('#errorDisplayModal').foundation('open');
            }
        },
        error: function (result) {
            $('#errorDisplayModal p').html(result);
            $('#errorDisplayModal').foundation('open');
        }
    });
}

function updateFilm(form, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            if (result.HasSucceeded == true) {
                $('#updateModal').foundation('close');
                var url = $('.current a').prop('href');
                getFilms(url, "#tableWrapper");
                displayResultMessage("Movie successfully updated!");
            }
            else {
                var form = $("#updateFormWrapper").html(result.view);
                $('#updateFormWrapper').removeData('validator').removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse(form);
                $('#updateModal').foundation('open');
            }
        },
        error: function () {
            $('#errorDisplayModal p').html('Request could not be executed');
                $('#errorDisplayModal').foundation('open');
        }
    });
}


function deleteFilm(id, url) {
    $.ajax({
        url: url,
        method: "post",
        data: { "id": id },
        success: function (result) {
            if (result.HasSucceeded == true) {
                $("#operationResult").html("Film successfully deleted");
                var target = "#tableWrapper";
                var url = $('.current a').prop('href');
                getFilms(url, target);
                displayResultMessage("Movie successfully deleted!");
            }
            else {
                $('#errorDisplayModal p').html(result);
                $('#errorDisplayModal').foundation('open')
            }
        },
        error: function () {
            $('#errorDisplayModal p').html('Request could not be executed');
            $('#errorDisplayModal').foundation('open')
        }
    });
};

function clearForm(form) {
    //reset jQuery Validate's internals
    $(form).find('input[type=text], textarea').val('');

    //for summary
    $(form).find('[data-valmsg-summary=true]')
        .removeClass('validation-summary-valid')
        .addClass('validation-summary-valid')
        .find('ul').empty();

    //for individual fields
    $(form).find('[data-valmsg-replace]')
        .removeClass('field-validation-error')
        .addClass('field-validation-valid')
        .empty();
};