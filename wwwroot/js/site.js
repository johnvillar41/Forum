$(document).ready(function () {
    jQueryModalGet = (url, title) => {
        $.ajax({
            type: 'GET',
            url: url,
            contentType: false,
            processData: false,
            success: function (response) {
                $('#form-modal .modal-body').html(response.html);
                $('#form-modal .modal-title').html(title);
                $('#form-modal').modal('show');
            },
            error: function (error) {
                console.log(err)
            }
        })
        return false;
    }
});