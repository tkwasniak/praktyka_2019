function getPagedFilms(url, target) {
    $.ajax({
        url: url,
        method: 'get',
        success: function (data) {
            $(target).replaceWith(data);
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
}

function createFilm(form, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            form.trigger("reset");
            getPagedFilms("Film/GetFilms", "#filmListWrapper");
            displayResultMessage("Movie successfully added!");
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
}


function getFilmForUpdate(id, url) {
    $.ajax({
        url: url,
        method: "get",
        data: { "id": id },
        success: function (result) {
            var form =$("#updateFormWrapper").html(result);
            $("#updateFormWrapper").removeData("validator").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse(form);
            $('#updateModal').foundation('open');
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
}

function updateFilm(form, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            if (result.success == true) {
                displayResultMessage("Movie successfully updated!");
                getPagedFilms("Film/GetFilms", "#filmListWrapper");
            }
            else {
                //obsluga bledu
            }
        },
        error: function () {
            alert("Something went wrong");
        }
    });
}

function deleteFilm(id, url) {
    $.ajax({
        url: url,
        method: "post",
        data: { "id": id },
        success: function (result) {
            if (result.success == true) {
                $("#operationResult").html("Film successfully deleted");
                var target = "#filmListWrapper";
                getPagedFilms("Film/GetFilms", target);
                displayResultMessage("Movie successfully deleted!");
            }
            else {

            }
        },
        error: function (error) {
            alert("Something went wrong");
        }
    });
};

