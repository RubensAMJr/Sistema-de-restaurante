using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int? ComandaId { get; set; }
        public double ValorTotal { get; set; }
        public IList<ItemPedido> Itens { get; set; }
        
    }
}