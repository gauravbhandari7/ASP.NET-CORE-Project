ShowInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    })
}

$(document).ready(function () {
    $("#btnSave").click(function () {
        var formdata = $("#form-modal").serialize();

        $.ajax({
            type: "POST",
            url: "/Flight/Create",
            data: formdata,
            success: function () {
                window.location.href = "/Index";
            }
        })
    })
    $("#btnClose").click(function () {
        window.location.href = "Flight/Index";
    })
})