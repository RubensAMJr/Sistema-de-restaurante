
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
                    console.log("oi");
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
                    
                } else {
                    $("#mensagem-erro").text(data.resposta).fadeOut(7000).css("color", "red");
                    setTimeout(function () {
                        $("#mensagem-erro").text(data.resposta).remove();
                    }, 7000)
                   
                    
                }
            },
            error: function (data) {
                
            }
        });
}


