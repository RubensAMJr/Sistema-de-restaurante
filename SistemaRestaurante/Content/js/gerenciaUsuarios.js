
$(document).ready(function () {
    $(".sucesso").toggle();
    $(".falha").toggle();
});
function removeUsuario(Nome) {
    event.preventDefault();
    $.ajax(
        {
            type: 'POST',
            url: 'RemoveUsuario',
            data: {
                Nome
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    $(".sucesso").text(data.resposta).toggle().fadeOut(7000);
                    setTimeout(function () {
                        $(".sucesso").text(data.resposta).toggle();
                    }, 7000)
                    $("#" + Nome).remove();

                } else {
                    $(".falha").text(data.resposta).toggle().fadeOut(6000);
                }
            }
        });
}

