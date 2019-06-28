
$(document).ready(function () {
    $(".btnDeleteFilm").click(function () {
        var id = $(this).attr("data-id");
        var url = $(this).attr("data-url");
        deleteFilm(id, url);
    });

    $("#btnAddFilm").click(function () {
        var url = $(this).attr("data-url");
        var form = $("#addFilmForm");
        form.validate();
        if (form.valid()) {
            addFilm(form, url);
        }
        else {
            //form is not valid
        };
    });

    $(".btnGetEditFilm").click(function () {
        var url = $(this).attr("data-url");
        var id = $(this).attr("data-id");
        getEditFilm(id, url);
    });


});

$(document).on("click", "#btnEditFilm", function () {
    var id = $(this).attr("data-id");
    var url = $(this).attr("data-url");
    var form = $("#editFilmForm");
    form.validate();
    if (form.valid()) {
        editFilm(form, id, url);
    }
    else {
        //form is not valid
    };
});

function getEditFilm(id, url) {
    $.ajax({
        url: url,
        method: "",
        data: { "id": id },
        success: function (result) {
            $("#formDiv").html(result);
        },
        error: {

        }
    });
}

function editFilm(form, id, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            alert(result.Id);
            $("#filmTable tr:last").after(result);

        },
        error: {}

    });
}


function addFilm(form, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            $("#operationResult").html("Film successfully added");
            $("#filmTable tr:last").after(result);
            form.trigger("reset");
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
}


function deleteFilm(id, url) {
    if (confirm("Are you sure?")) {
        $.ajax({
            url: url,
            method: "post",
            data: { "id": id },
            success: function (result) {
                if (result.success == true) {
                    $("#row_" + id).remove();
                    $("#operationResult").html("Film successfully deleted");
                }
                else {
                    $("#operationResult").html("Deletion failed");
                }
            },
            error: function (error) {
                alert("Something went wrong");
            }
        });
    }
};

