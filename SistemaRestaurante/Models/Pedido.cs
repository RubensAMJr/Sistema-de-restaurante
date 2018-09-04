using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ComandaId { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public IList<ItemPedido> Itens { get; set; }
    }
}