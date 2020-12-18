$(document).ready(function () {
    $('#appointments').DataTable(
        {
            columnDefs: [
                {
                    orderable: false,
                    targets: ["nosort"]
                }
            ]
        }
    );
    if (sessionStorage.getItem("Approve")) {
        $.notify('Appointment Approved!','success');
        sessionStorage.clear();
    }
    if (sessionStorage.getItem("Reject")) {
        $.notify('Appointment Rejected!', 'success');
        sessionStorage.clear();
    }
});
$("#appointments").on('click', 'button', function() {
    var url = $(this).attr('data-url');
    var action = $(this).attr('data-action');
    $.ajax({
        url: url,
        method: 'GET',
        success: function () {
            sessionStorage.setItem(action, action);
            window.location.reload();
        }
    });

});
