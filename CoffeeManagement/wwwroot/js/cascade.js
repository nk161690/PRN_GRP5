$(document).ready(function () {
    getCate();
    $('#item').html('<option>-- Select an item --</option>');
    $('#category').change(function () {
        
    });
});

function getCate() {
    $.ajax({
        url: '/TablesCoffees/Category',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#item').append('<option value=' + data.ID + '>' + data.Name + '</option>');
            });
        }
    });
}