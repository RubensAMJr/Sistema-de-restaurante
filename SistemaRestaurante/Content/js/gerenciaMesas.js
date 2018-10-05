
function removeMesa(numeroMesa) {
    event.preventDefault();
    $.ajax(
        {
            type: 'POST',
            url: 'RemoveMesa',
            data: {
                numeroMesa
            },
            cache: false,
            async: true,
            success: function () {
                $("#" + numeroMesa).remove();
                mostraMensagem("Mesa foi removida", false);


            }
        });
}
function adicionaMesa() {
    event.preventDefault();
    var numeroMesa = $("#numeroMesa").val();
    $.ajax(
        {
            type: 'POST',
            url: 'AdicionaMesa',
            data: {
                numeroMesa
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    var linha = $("<tr>").attr("id", data.Mesa.Numero);
                    var colunaId = $("<td>").text(data.Mesa.MesaId);
                    var colunaNumero = $("<td>").text(data.Mesa.Numero);
                    var colunaBotao = $("<td>");

                    var btnRemover = $("<button>").addClass("btn").addClass("btn-sm").addClass("btn-danger").attr("onclick", "removeMesa(" + data.Mesa.Numero + ")").text("Remover");

                    colunaBotao.append(btnRemover);
                    linha.append(colunaId);
                    linha.append(colunaNumero);
                    linha.append(colunaBotao);
                    $(".tabela-Mesa").append(linha);
                    mostraMensagem("Mesa adicionada com sucesso", true);
                } else {
                    mostraMensagem(data.resposta, false);
                }
            },
            error: function (data) {
                
            }
        });
}

function mostraMensagem(resposta, success) {
    var x = $("#snackbar");
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


