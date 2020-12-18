$(document).ready(function () {
    $('#slots-by-doctor').DataTable(
        {
            columnDefs: [
                {
                    orderable: false,
                    targets: ["nosort"]
                }
            ]
        }
    );
});
///Patient/RequestAppointment /@slot.Id
function requestSlot(Id) {
    var success = 'Success!';
    var alreadyRequested = 'Already Submitted!';
    var failed = 'Failed!';
    $.ajax({
        url: '/Patient/RequestAppointment/' + Id,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data.message === success) {
                $.notify('Request Submitted Successfully!', "success");
            } else if (data.message === alreadyRequested) {
                $.notify('Already Submitted Before!', "warn");
            } else if (data.message === failed) {
                $.notify('Something went wrong!', "error");
            }
        }
    });
}