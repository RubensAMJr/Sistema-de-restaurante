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
                    $("#" + Nome).remove();
                    mostraMensagem2(data.resposta, false);
                } else {
                    mostraMensagem2(data.resposta, false);
                }
            }
        });
}

function mostraMensagem2(resposta, success) {
    var x = $(".snackbar2");
    console.log(x);
    x.text(resposta);
    if (success == true) {
        x.css("background-color", "green");
    } else {
        x.css("background-color", "red");
    }
    x.addClass("show");
    setTimeout(function () {
        x.removeClass("show")
    }, 3000);
}

