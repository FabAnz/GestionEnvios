$(function () {
    // Recorremos todos los inputs que tienen errores
    $('input.input-validation-error').each(function () {
        var input = $(this);
        input.on('input', function () {
            // Cuando el usuario empieza a escribir, revalidamos el campo
            if (input.valid()) {
                input.removeClass('input-validation-error');
                input.next('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid').text('');
            }
        });
    });
});