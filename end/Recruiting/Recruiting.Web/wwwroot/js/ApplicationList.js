$(document).ready(function () {
    $(document).on("click", "#icon-create", createApplication);
});

function createApplication() {
    debugger
    var newApplication = $('.sample-edit-row').clone();
    var form = newApplication.find('#form-application');

    $('#table-applications tbody').prepend(newApplication);
}