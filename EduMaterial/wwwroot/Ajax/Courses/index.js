$(document).ready(function () {
    // Toggle the add course container
    $("#addCourseButton").click(function () {
        $("#addCourseContainer").toggle();
    });

    // Add course button click event
    $("#clicklendi").click(function (e) { 
        e.preventDefault();
        var course = {
            name: $('#courseName').val(),
            description: $('#courseDescription').val(),
            durationInHours: $('#durationInHours').val(),
            filepath: $('#filepath').val(),
            fileSize: $('#fileSize').val()
        };
        
        $.ajax({
            url: '/Course/AddCourse',
            method: 'POST',
            data: course,
            success: function (response) {
                $('#addCourseModal').modal('hide');
                updateCourseTable();
            },
            error: function (xhr, status, error) {
                alert('Error: ' + error);
            }
        });
    });
    // $('#addCourseForm').submit(function (e) {
    //     e.preventDefault(); //Butonu dinle
    //     var course = {
    //         name: $('#courseName').val(),
    //         description: $('#courseDescription').val(),
    //         durationInHours: $('#durationInHours').val(),
    //         filepath: $('#filepath').val(),
    //         fileSize: $('#fileSize').val()
    //     };

    //     $.ajax({
    //         url: '/Course/AddCourse',
    //         method: 'POST',
    //         data: course,
    //         success: function (response) {
    //             $('#addCourseModal').modal('hide');
    //             updateCourseTable();
    //         },
    //         error: function (xhr, status, error) {
    //             alert('Error: ' + error);
    //         }
    //     });
    // });

    function updateCourseTable() {
        location.reload();
    }
    loadCategories();
});
