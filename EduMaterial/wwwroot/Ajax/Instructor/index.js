$(document).ready(function () {
    // Yeni Eğitmen Ekle
    $("#createForm").submit(function (event) {
        event.preventDefault();

        var instructorName = $("#instructorName").val().trim();

        if (instructorName === "") {
            alert("Eğitmen adı boş olamaz!");
            return;
        }

        $.ajax({
            url: "/Instructor/Created",
            type: "POST",
            data: { Name: instructorName },
            success: function (response) {
                // Başarı mesajı
                alert("Eğitmen başarıyla eklendi!");

                // Tabloyu güncelle
                $("#instructorTableBody").append(`
                                    <tr>
                                        <td>${instructorName}</td>
                                        <td>
                                            <a href="/Instructor/Details?Id=newId" class="btn btn-info btn-sm">Detaylar</a>
                                        </td>
                                    </tr>
                                `);

                $("#instructorName").val("");
                $('#myModal').modal('hide');
            },
            error: function () {
                alert("Eğitmen eklenirken bir hata oluştu!");
            }
        });
    });
});