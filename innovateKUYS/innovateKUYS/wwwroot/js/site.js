// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function loadStudentDetail(id) {
    $("#StudentDetay .modal-content").load("/Student/GetStudentDetail/" + id)
}
// Write your JavaScript code.
$(document).ready(function () {
    $('#StudentDetay').DataTable({
        columnDefs: [
            {
                targets: [0],
                orderData: [0, 1],
            },
            {
                targets: [1],
                orderData: [1, 0],
            },
            {
                targets: [4],
                orderData: [4, 0],
            },
        ],
    });
});



