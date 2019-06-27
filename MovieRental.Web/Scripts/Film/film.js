
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
        
    });
});



function addFilm(form, url) {
    $.ajax({
        url: url,
        method: "post",
        data: form.serialize(),
        success: function (result) {
            if (result.success == true) {
                $("#row_" + id).remove();
            }
        },
        error: function (result) {
            // wiadomosc zwrocic do buttona
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
                }
            },
            error: function (result) {
                // wiadomosc zwrocic do buttona
                alert("Something went wrong");
            }
        });
    }
};

