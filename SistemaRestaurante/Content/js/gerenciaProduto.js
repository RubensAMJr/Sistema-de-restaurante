
$(document).ready(function () {
    $(".sucesso-adiciona").toggle();
    $(".falha-adiciona").toggle();

    $("#botaoAdicionar").click(function () {
        $("#ModalAdicionar").modal();
    });
    $("#botaoEditar").click(function () {
        var tdProduto = $(".selected").children();
        $("#nomeEditar").val(tdProduto[0].textContent);
        $("#precoEditar").val(tdProduto[1].textContent.replace(",", "."));
        $("#descricaoEditar").val(tdProduto[2].textContent);
        $("#ModalEditar").modal();
    });
});

function adicionarProduto() {
    event.preventDefault();
    var nomeProduto = $("#nomeProduto").val();
    var precoProduto = $("#precoProduto").val();
    var descricao = $("#descricao").val();
    console.log(nomeProduto);
    console.log(precoProduto);
    console.log(descricao);
    $.ajax(
        {
            type: 'POST',
            url: 'AdicionaProduto',
            data: {
                nomeProduto, precoProduto, descricao
            },
            cache: false,
            async: true,

            success: function (data) {
                if (data.success == true) {
                    var linha = $("<tr>").attr("id", data.Produto.Nome);
                    var colunaNome = $("<td>").text(data.Produto.Nome);
                    var colunaPreco = $("<td>").text(data.Produto.Preco);
                    $(colunaPreco).text(colunaPreco.textContent.replace(".", ","));
                    var colunaDescricao = $("<td>").text(data.Produto.Descricao);
                    var colunaFalta = $("<td>");
                    if (data.Produto.EstaEmFalta == true) {
                        colunaFalta.text("SIM");
                    } else {
                        colunaFalta.text("NÃO");
                    }
                    var link = $("<a>").attr("href", "#").attr("onclick", "alteraFalta()");
                    var span = $("<span>").attr("style", "float:right;");
                    var icone = $("<i>").addClass("fa").addClass("fa-toggle-on");
                    span.append(icone);
                    link.append(span);
                    colunaFalta.append(link);

                    linha.append(colunaNome);
                    linha.append(colunaPreco);
                    linha.append(colunaDescricao);
                    linha.append(colunaFalta);

                    $("#tabela-produtos").append(linha);

                    $(".sucesso-adiciona").text("Produto Adicionado com sucesso").toggle().fadeOut(6000);

                } else {
                    $(".falha-adiciona").text(data.resposta).toggle().fadeOut(6000);
                }
            },
            error: function (data) {
                console.log("erro");
            }
        });
}

function alteraFalta() {
    var tdProduto = $(".selected").children();
    var nomeProduto = tdProduto[0].textContent;
    $.ajax(
        {
            type: 'POST',
            url: 'AlteraProduto',
            data: {
                nomeProduto
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    var tr = $(".selected").children()[3];
                    $(tr).text(data.resposta);
                } else {

                }
            }
        });
}

function removeProduto() {
    event.preventDefault();
    var tdProduto = $(".selected").children();
    var nomeProduto = tdProduto[0].textContent;
    $.ajax(
        {

            type: 'POST',
            url: 'RemoveProduto',
            data: {
                nomeProduto
            },
            cache: false,
            async: true,
            success: function () {
                $(".selected").remove();
            }
        });
}

function editaProduto() {
    event.preventDefault();
    var tdProduto = $(".selected").children();
    var nomeOriginal = tdProduto[0].textContent;
    var nomeEditado = $("#nomeEditar").val();
    var precoEditado = $("#precoEditar").val();
    console.log(precoEditado);
    var descricaoEditada = $("#descricaoEditar").val();
    $.ajax(
        {
            type: 'POST',
            url: 'EditaProduto',
            data: {
                nomeOriginal, nomeEditado, precoEditado, descricaoEditada
            },
            cache: false,
            async: true,
            success: function (data) {
                if (data.success == true) {
                    var trNome = $(".selected").children()[0];
                    var trPreco = $(".selected").children()[1];
                    var trDescricao = $(".selected").children()[2];
                    $(trNome).text(data.Produto.Nome);
                    var preco = data.Produto.Preco;
                    $(trPreco).text(data.format);
                    //$(trPreco).text(trPreco.textContent.replace(".", ","))
                    $(trDescricao).text(data.Produto.Descricao);
                } else {

                }
            }
        });
}





