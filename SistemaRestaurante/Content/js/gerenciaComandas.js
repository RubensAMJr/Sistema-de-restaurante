function adicionaComanda() {
    event.preventDefault();
    var numeroComanda = $("#numeroComanda").val();
    $.ajax(
        {
            type: 'POST',
            url: 'AdicionaComanda',
            data: {
                numeroComanda
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    var linha = $("<tr>").attr("id", data.Comanda.Id);
                    var colunaId = $("<td>").text(data.Comanda.Id);
                    var colunaNumero = $("<td>").text(data.Comanda.Numero);
                    var colunaBotao = $("<td>");

                    var btnRemover = $("<button>").addClass("btn").addClass("btn-sm").addClass("btn-danger").attr("onclick", "removeComanda(" + data.Comanda.Numero + ")").text("Remover");

                    colunaBotao.append(btnRemover);
                    linha.append(colunaId);
                    linha.append(colunaNumero);
                    linha.append(colunaBotao);
                    $(".tabela-Comanda").append(linha);
                    mostraMensagem3("Comanda adicionada com sucesso",true);
                } else {
                    mostraMensagem3(data.resposta,false);
                }
            },
            error: function (data) {
            }
        });
}
function removeComanda(nmrComanda) {
    var numeroComanda = parseInt(nmrComanda);
    event.preventDefault();
    $.ajax(
        {
            type: 'POST',
            url: 'RemoveComanda',
            data: {
                numeroComanda
            },
            cache: false,
            async: true,
            success: function (data) {
                $("#" + data.Id).remove();
                mostraMensagem3("Comanda removida",false);
            }
        });
}

function mostraMensagem3(resposta, success) {
    var x = $(".snackbar3");
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
