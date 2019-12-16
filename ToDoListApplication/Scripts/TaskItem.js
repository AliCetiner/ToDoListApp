
$(document).ready(function () {
    //debugger;
    var todayDateSeconds = new Date().getSeconds();
    var timeDelayMs = (60 - todayDateSeconds) * 1000;

    setTimeout(function () {

        CheckItemsEndDate();

        setInterval(function () {

            CheckItemsEndDate();

        }, 60000);

    }, timeDelayMs);

    $('#divUpdateItemPopUp').on('hidden.bs.modal', function () {
        $('#tableToDoList tbody tr').removeClass("selected");
    });

});

function GetDateStrFormat(date) {

    return new Date(parseInt(date.replace("/Date(", "").replace(")/", ""), 10));
}

function AddItem() {

    $("#formAddTaskItem").validate({
        // Specify the validation rules
        rules: {
            Description: { required: true },
            EndDate: { required: true }
        },
        // Specify the validation error messages
        messages: {
            Description: { required: "Please enter description" },
            EndDate: { required: "Please enter end date" }
        },
        submitHandler: function (form) {

            //debugger;
            var modelx = $("#formAddTaskItem").serialize();

            $.post("/Home/AddItem", modelx, function (result) {

                //debugger;

                var date = GetDateStrFormat(result.EndDate);
                var date_format_str = date.toLocaleDateString() + " " + date.toLocaleTimeString([], { timeStyle: 'short' });

                $("#tableToDoList tbody").append('<tr data-id="' + result.ID + '"><td>' + result.Description + '</td><td>' + date_format_str + '</td><td><button type="button" class="btn btn-primary btn-xs" onclick="GetItem(' + result.ID + ')">Update</button> <button type="button" class="btn btn-danger btn-xs" onclick="DeleteItem(' + result.ID + ')">Delete</button></td></tr>');

                $("#txtDescription").val(null);
                $("#txtEndDate").val(null);

            });

        }
    });

}

function DeleteItem(id) {

    $.ajax({
        url: '/Home/DeleteItem',
        type: 'POST',
        cache: false,
        datatype: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify({ id: id }),
        success: function (result) {

            $('#tableToDoList tbody tr[data-id="' + result + '"]').fadeOut().remove();

        },
        error: null,
    });

}

function GetItem(id) {

    $.ajax({
        url: '/Home/GetItem',
        type: 'POST',
        cache: false,
        datatype: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify({ id: id }),
        success: function (result) {
            //debugger;
            $('#tableToDoList tbody tr').removeClass("selected");
            $('#tableToDoList tbody tr[data-id="' + result.ID + '"]').addClass("selected");

            $("#divUpdateItemPopUp").modal("show");

            $("#txtID").val(id);

            $("#txtPopUpDescription").val(result.Description);

            var date = GetDateStrFormat(result.EndDate);

            var dateTimeStr = date.getFullYear().toString() + "-" + (date.getMonth() + 1).toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false }) + "-" + date.getDate().toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false }) + "T" + date.toLocaleTimeString();

            $("#txtPopUpEndDate").val(dateTimeStr);
            //$("#txtTime").val("2018-06-14T19:30:00");
        },
        error: null,
    });
}

function UpdateItem() {

    $("#formUpdateTaskItem").validate({
        // Specify the validation rules
        rules: {
            Description: { required: true },
            EndDate: { required: true }
        },
        // Specify the validation error messages
        messages: {
            Description: { required: "Please enter description" },
            EndDate: { required: "Please enter end date" }
        },
        submitHandler: function (form) {

            //debugger;
            var modelx = $("#formUpdateTaskItem").serialize();

            $.post("/Home/UpdateItem", modelx, function (result) {

                //debugger;

                var date = GetDateStrFormat(result.EndDate);
                var date_format_str = date.toLocaleDateString() + " " + date.toLocaleTimeString([], { timeStyle: 'short' });

                $("#tableToDoList tbody tr.selected").children().first().text(result.Description);
                $("#tableToDoList tbody tr.selected").children().eq(1).text(date_format_str);

                $("#divUpdateItemPopUp").modal("hide");
                $('#tableToDoList tbody tr').removeClass("selected");

            });

        }
    });

}


function CheckItemsEndDate() {

    $.ajax({
        url: '/Home/CheckItemsEndDate',
        type: 'POST',
        cache: false,
        datatype: 'application/json',
        contentType: 'application/json',
        data: null,
        success: function (result) {
            //debugger;

            if (result.length > 0) {
                $("#divItemReminderPopUp").modal("show");
                //$("#divUpdateItemPopUp").modal("hide");

                $("#tableItemReminder tbody").html("");

                for (var i = 0; i < result.length; i++) {
                    var date = GetDateStrFormat(result[i].EndDate);
                    var date_format_str = date.toLocaleDateString() + " " + date.toLocaleTimeString([], { timeStyle: 'short' });

                    $("#tableItemReminder tbody").append('<tr data-id="' + result[i].ID + '"><td>' + result[i].Description + '</td><td>' + date_format_str + '</td></tr>');
                }
            }

        },
        error: null,
    });

}