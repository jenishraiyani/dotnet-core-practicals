var successMessage = "Student added successfully";
var deleteMessage = "Student deleted successfully";
var errorMessage = "Something went wrong!!!";
var confirmMessage = "Are you sure you want to delete this record??";

function showMessage(type, message) {
    swal({
        title: type,
        text: message,
        icon: type,
        showCancelButton: false,
        showConfirmButton: true

    }).then((willDelete) => {
        location.reload(true);
    });
}

function showForm(id) {

    if (id == "add") {
        $.ajax({
            type: "GET",
            url: "/Student/Create",
            success: function (result) {

                $("#form-content").html(result);
                $("#studentForm").modal('show');
            }
        });
    }
    else {
        $.ajax({
            type: "GET",
            url: "/Student/Edit?id=" + id,
            success: function (result) {
                $("#form-content").html(result);
                $("#studentForm").modal('show');
            }
        });
    }
}

function addStudentDetails(action) {

    $("#student-form").validate({

        rules: {
            StudentName: {
                required: true,
                minlength: 3
            },
            Phone: {
                required: true,
                number: true,
                min: 10
            },
            Email: {
                required: true,
                email: true
            },
        },
        messages: {
            StudentName: {
                required: "Please enter student name",
                minlength: "Name should be at least 3 characters"
            },
            Phone: {
                required: "Please enter phone number",
                number: "Please enter mobile number as a numerical value",
                min: "Mobile number must have 10 digits"
            },
            Email: {
                required: "Please enter email",
                email: "The email should be in the format: jenishraiyani@gmail.com"
            },
        },

        submitHandler: function (form) {
            var studentData = {
                "studentName": $('#StudentName').val(),
                "email": $('#Email').val(),
                "phone": $('#Phone').val(),
                "studentId": $('#StudentId').val()
            }
            $.ajax({
                type: action,
                url: "api/Student",
                contentType: 'application/json',
                data: JSON.stringify(studentData),
                success: function (data, textStatus, xhr) {
                    showMessage('success', successMessage);
                },
                error: function (xhr, textStatus, errorThrown) {
                    showMessage('error', errorMessage);
                }
            });
        }
    });
}


$("#student .js-delete").on("click", function () {

    var button = $(this);
    let id = $(this).attr("data-student-id");

    swal({
        title: "Are you sure?",
        text: confirmMessage,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: 'Api/Student?id=' + id,
                method: "DELETE",
                success: function (result) {
                    button.parents("tr").remove();
                    showMessage('success', deleteMessage);
                },
                error: function () {
                    showMessage('error', errorMessage);
                }
            });
        }
           
    });   
});