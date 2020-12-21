$(document).ready(function () {
    $("#users-table").DataTable({
        columnDefs: [
            {
                orderable: false,
                targets: ["nosort"]
            }
        ]
    });
    if (sessionStorage.getItem("message")) {
        $.notify("Account Deleted!", "success");
        sessionStorage.clear();
    }
});
$("#users-table").on("click", "button", function () {
    var u_id = $(this).attr("data-id");
    bootbox.confirm({
        message: "Are you sure you want to delete this account?",
        size: "medium",
        centerVertical: true,
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: "/Admin/DeleteAccount/" + u_id,
                    success: function () {
                        sessionStorage.setItem("message", "success");
                        window.location.reload();
                    }
                });
            }
        }
    });
})
$("#users-table").on("change", "input[type='checkbox']", function () {
    var checkBox = $(this).attr('id');
    bootbox.confirm({
        message: ($("#" + checkBox).prop('checked')) ? "Are you sure you want to deactivate this account?" :"Are you sure you want to activate this account?",
        size: "medium",
        centerVertical: true,
        callback: function (result) {
            if (result) {
                if ($("#" + checkBox).prop('checked')) {
                    $.ajax({
                        url: "/Admin/DeactivateAccount/" + checkBox,
                        success: function () {
                            $.notify("Account Deactivated!", "success");
                        }
                    });
                } else {
                    $.ajax({
                        url: "/Admin/ActivateAccount/" + checkBox,
                        success: function () {
                            $.notify("Account Activated!", "success");
                        }
                    });
                }
            } else {
                if ($("#" + checkBox).prop('checked')) {
                    $("#" + checkBox).prop('checked', false);
                } else {
                    $("#" + checkBox).prop('checked', true);
                }
                
            }
        }
    });
})