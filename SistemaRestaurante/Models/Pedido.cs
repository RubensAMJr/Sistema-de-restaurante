using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Pedido
    {
        private static int numeroIndex;
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ComandaId { get; set; }
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public IList<ItemPedido> Itens { get; set; }
        public Pedido(DateTime data, double valorTotal,int comandaId)
        {
            numeroIndex++;
            Numero = numeroIndex;
            Data = data;
            ValorTotal = valorTotal;
            ComandaId = comandaId;
            
        }
    }
}