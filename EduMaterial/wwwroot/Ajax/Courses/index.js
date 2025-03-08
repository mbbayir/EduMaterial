$(document).ready(function () {
    // Initialize Select2 on categories and instructors dropdowns
    $('#categories, #instructors , #producers').select2({
        placeholder: "Select an option",
        allowClear: true,
        dropdownParent: $('#addCourseModal')
    });

    $("#saveCourseButton").click(function (e) {
        e.preventDefault();
        var course = {
            Name: $('#courseName').val(),
            Description: $('#courseDescription').val(),
            DurationInHours: $('#durationInHours').val(),
            Filepath: $('#filepath').val(),
            FileSize: $('#fileSize').val(),
            InstructorIds: $("#instructors").val(),
            CategoryIds: $("#categories").val(),
            ProducerIds: $("#producers").val(),
        };
        // console.log(course);
        // return;

        $.ajax({
            url: '/Course/AddCourse',
            method: 'POST',
            data: {
                course: course
            },
            success: function (response) {
                $('#addCourseModal').modal('hide');
                // addCourseToTable(response);
                alert('Course successfully saved');
                loadCourses(); // Refresh course list
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error adding course:', errorThrown);
                alert('Error: ' + errorThrown);
            }
        });
    });

    loadCategories();
    loadInstructors();
    loadProducers();
    loadCourses();


    document.getElementById("courseDescription").addEventListener("input", function () {
        var maxLength = 100;
        if (this.value.length > maxLength) {
            this.value = this.value.slice(0, maxLength);
        }
    });
});
// function addCourseToTable(course) {
//     // Kategoriler için badge oluşturma
//     var categories = Array.isArray(course.categoryIds) ? course.categoryIds.map(function (id) {
//        var category = $('#categories option[value="' + id + '"]').text();
//        return '<span class="badge badge-secondary">' + category + '</span>';
//    }).join(' ') : '';
   
//    // Eğitmenler için badge oluşturma
//    var instructors = Array.isArray(course.instructorIds) ? course.instructorIds.map(function (id) {
//        var instructor = $('#instructors option[value="' + id + '"]').text();
//        return '<span class="badge badge-secondary">' + instructor + '</span>';
//    }).join(' ') : '';
   
//     // Üreticiler için badge oluşturma
//     var producers = Array.isArray(course.producerIds) ? course.producerIds.map(function (id) {
//        var producer = $('#producers option[value="' + id + '"]').text();
//        return '<span class="badge badge-secondary">' + producer + '</span>';
//    }).join(' ') : '';
   
//        var newRow = '<tr>' +
//            '<td>' + course.name + '</td>' +
//            '<td>' + course.description + '</td>' +
//            '<td>' + course.durationInHours + '</td>' +
//            '<td>' + course.filepath + '</td>' +
//            '<td>' + course.fileSize + '</td>' +
//            '<td>' + instructors + '</td>' +
//            '<td>' + categories + '</td>' +
//            '<td>' + producers + '</td>' +
//            '</tr>';
   
//        $('#courseTable tbody').append(newRow);
//    }

function loadCategories() {
    $.ajax({
        method: "GET",
        url: "/Category/GetAllCategories",
        success: function (response) {
            let data = response.map(category => {
                return {
                    id: category.id,
                    text: category.name
                };
            });
            $('#categories').select2({
                data: data,
                placeholder: "Select categories",
                allowClear: true
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error loading categories:', errorThrown);
        }
    });
}
function loadInstructors() {
    $.ajax({
        method: "GET",
        url: "/Course/GetAllInstructors",
        success: function (response) {
            let data = response.map(instructor => {
                return {
                    id: instructor.id,
                    text: instructor.name
                };
            });
            $('#instructors').select2({
                data: data,
                placeholder: "Select instructors",
                allowClear: true
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error loading instructors:', errorThrown);
        }
    });
}
function loadProducers() {
    $.ajax({
        method: "GET",
        url: "/Course/GetAllProducers",
        success: function (response) {
            let data = response.map(producer => {
                return {
                    id: producer.id,
                    text: producer.name
                };
            });
            $('#producers').select2({
                data: data,
                placeholder: "Select producers",
                allowClear: true
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error loading producers:', errorThrown);
        }
    });
}

function loadCourses() {
    $('#courseTable tbody').empty();
    $.ajax({
        type: "GET",
        url: "/Course/GetAllCourseJson",
        success: function (response) {
            console.log(response);
            response.forEach(function (course) {
                // Eğitmenler
                const instructors = course.instructorCourses.map(ic => ic.instructor ? ic.instructor.name : 'N/A').join(', ');
                
                // Kategoriler
                const categories = course.categoryCourses.map(cc => cc.category ? cc.category.name : 'N/A').join(', ');
                
                // Üreticiler
                const producers = course.courseProducers.map(cp => cp.producer ? cp.producer.name : 'N/A').join(', ');
                
                // Tabloya yeni satır ekleme
                const newRow = `
                    <tr>
                        <td>${course.name}</td>
                        <td>${course.description}</td>
                        <td>${course.durationInHours}</td>
                        <td>${course.filepath}</td>
                        <td>${course.fileSize}</td>
                        <td>${instructors}</td>
                        <td>${categories}</td>
                        <td>${producers}</td>
                    </tr>
                `;
                
                $('#courseTable tbody').append(newRow);
            });
        },
        error: function (xhr, status, error) {
            console.error("Error fetching course data:", error);
        }
    });
}
