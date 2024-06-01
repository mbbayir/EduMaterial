$(document).ready(function () {
    loadCategories();
    loadCourses();


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
            fileSize: $('#fileSize').val(),
            categoryIds : $("#categories").val(),
        };
        
        $.ajax({
            url: '/Course/AddCourse',
            method: 'POST',
            data: course,
            success: function (response) {
                $('#addCourseModal').modal('hide');
                updateCourseTable(response);
            },
            error: function (xhr, status, error) {
                alert('Error: ' + error);
            }
        });
    });


    function updateCourseTable() {
        location.reload();
    }

});

function loadCategories(){
    $.ajax({
        method: "GET",
        url: "/Category/GetAllCategories",
        success: function (response) {
            let categories = response;
            $('#categories').empty();

            categories.forEach(category => {
                let option = $('<option></option>')
                    .attr('value', category.id)
                    .text(category.name);
                $('#categories').append(option);
            });
        }
    });

}
function loadCourses(){
    $.ajax({
        method: "GET",
        url: "/Course/GetAllCourses",
        success: function (response) {
            response.forEach(course => {
                addCourseToTable(course);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error: ' + errorThrown);
        }
    });
}
