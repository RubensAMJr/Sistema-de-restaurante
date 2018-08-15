using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public string Observacao { get; set; }


    }
}