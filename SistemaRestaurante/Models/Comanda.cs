using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Comanda
    {

        public int Id { get; set; }
        public string Numero { get; set; }
        public double ValorTotal { get; set; }
    }
}