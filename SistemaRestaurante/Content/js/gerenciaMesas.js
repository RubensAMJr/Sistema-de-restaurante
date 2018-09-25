$(document).ready(function () {
    $(".sucesso-mesa").toggle();
    $(".falha-mesa").toggle();
});

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
                $(".sucesso-mesa").text("Mesa removida com sucesso").toggle().fadeOut(6000);

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

                    $(".sucesso-mesa").text("Mesa adicionada com sucesso").toggle().fadeOut(6000);
                    
                } else {
                    $(".falha-mesa").text(data.resposta).toggle().fadeOut(6000);
                }
            },
            error: function (data) {
                
            }
        });
}


