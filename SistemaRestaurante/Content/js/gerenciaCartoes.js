function adicionaCartao() {
    event.preventDefault();
    var nomeCliente = $("#nomeCliente").val();
    var numeroCartao = $("#numeroCartao").val();
    $.ajax(
        {
            type: 'POST',
            url: 'AdicionaCartao',
            data: {
                nomeCliente, numeroCartao
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    var linha = $("<tr>").attr("id", data.Cartao.NumeroCartao);
                    var colunaId = $("<td>").text(data.Cartao.Id);
                    var colunaNome = $("<td>").text(data.Cartao.NomeCliente);
                    var colunaNumero = $("<td>").text(data.Cartao.NumeroCartao);
                    var colunaBotao = $("<td>");

                    var btnRemover = $("<button>").addClass("btn").addClass("btn-sm").addClass("btn-danger").attr("onclick", "removeCartao(" + data.Cartao.NumeroCartao + ")").text("Remover");

                    colunaBotao.append(btnRemover);
                    linha.append(colunaId);
                    linha.append(colunaNome);
                    linha.append(colunaNumero);
                    linha.append(colunaBotao);
                    $(".tabela-Cartao").append(linha);
                    $(".sucesso-cartao").text("Cartão adicionado com sucesso").toggle().fadeOut(6000);
                    mostraMensagem4("Cartão adicionado com sucesso",true);
                } else {
                    $(".falha-cartao").text(data.resposta).toggle().fadeOut(6000);
                    mostraMensagem4(data.resposta, false);
                }
            },
            error: function (data) {

            }
        });
}

function removeCartao(numeroCartao) {
    event.preventDefault();
    $.ajax(
        {
            type: 'POST',
            url: 'RemoveCartao',
            data: {
                numeroCartao
            },
            cache: false,
            async: true,
            success: function () {
                $("#" + numeroCartao).remove();
                mostraMensagem4("Cartão removido",false);
            }
        });
}

function mostraMensagem4(resposta, success) {
    var x = $(".snackbar4");
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




