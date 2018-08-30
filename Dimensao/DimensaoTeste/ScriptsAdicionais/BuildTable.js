$(document).ready(function () {
    $.ajax({
        url: '/TaskLists/BuildTaskListTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }
    });
});