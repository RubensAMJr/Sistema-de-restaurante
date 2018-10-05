// Call the dataTables jQuery plugin
var tabela = $('#dataTable').DataTable(
    {
        'dom': 'Bftlrip',

        buttons: [
            {
                text: 'Adicionar',
                attr: {
                    id: 'botaoAdicionar'
                }
            },
            {
                extend: 'selectedSingle',
                text: 'Editar',
                attr: {
                    id: 'botaoEditar'
                }
            },
            {
                extend: 'selectedSingle',
                text: 'Deletar',
                attr: {
                    id: 'botaoDeletar',
                    onclick: 'removeProduto()'

                }
            },
            {
                extend: 'selectedSingle',
                text: 'Alterar Falta',
                attr: {
                    id: 'botaoAlterar',
                    onclick: 'alteraFalta()'
                }
            }

        ],

        select: {
            style: 'single'
        },

        "language":
            {
                "info": "Mostrando _START_ até _END_ de _TOTAL_ entradas.",
                "infoEmpty": "Mostrando 0 de 0 até 0 entradas",
                "lengthMenu": "Mostrar _MENU_ entradas",
                "search": "Procurar:",
                "paginate": {

                    "next": "Próxima",
                    "previous": "Anterior"
                }
            },

        'ajax': {
            "type": "POST",
            "url": '/BuscaProdutos'
        },
        "columns": [
            { "data": "Nome" },
            {
                render: function (data, type, row, meta) {
                    return Number.parseFloat(row.Preco).toFixed(2).replace(".", ",");
                }
            },
            { "data": "Descricao" },
            {
                render: function (data, type, row, meta) {
                    return row.EstaEmFalta ? "SIM" : "NÃO";
                }
            }
        ]
    }
);
