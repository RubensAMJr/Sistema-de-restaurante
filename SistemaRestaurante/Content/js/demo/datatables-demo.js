// Call the dataTables jQuery plugin
$(document).ready(function () {
    $('#dataTable').DataTable(
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
                    text: 'Editar',
                    attr: {
                        id: 'botaoEditar'
                    }
                },
                {
                    text: 'Deletar',
                    attr: {
                        id: 'botaoDeletar',
                        onclick: 'removeProduto()'
                        
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
            }
        }
    );
    
    
});
