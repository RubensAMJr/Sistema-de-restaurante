$(document).ready(function () {
    $(".sucesso-comanda").toggle();
    $(".falha-comanda").toggle();
});
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
                    console.log("oi");
                    var linha = $("<tr>").attr("id", data.Comanda.Numero);
                    var colunaId = $("<td>").text(data.Comanda.Id);
                    var colunaNumero = $("<td>").text(data.Comanda.Numero);
                    var colunaBotao = $("<td>");

                    var btnRemover = $("<button>").addClass("btn").addClass("btn-sm").addClass("btn-danger").attr("onclick", "removeComanda(" + data.Comanda.Numero + ")").text("Remover");

                    colunaBotao.append(btnRemover);
                    linha.append(colunaId);
                    linha.append(colunaNumero);
                    linha.append(colunaBotao);
                    $(".tabela-Comanda").append(linha);
                    $(".sucesso-comanda").text("Comanda adicionada com sucesso").toggle().fadeOut(6000);
                } else {
                    $(".falha-comanda").text(data.resposta).toggle().fadeOut(6000);
                }
            },
            error: function (data) {
            }
        });
}
function removeComanda(numeroComanda) {
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
            success: function () {
                $("#" + numeroComanda).remove();
                $(".sucesso-comanda").text("Comanda removida com sucesso").toggle().fadeOut(6000);
            }
        });
}
