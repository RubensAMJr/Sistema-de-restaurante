using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Cartao
    {
        public Cartao(int numeroCartao, string nomeCliente)
        {
            NumeroCartao = numeroCartao;
            NomeCliente = nomeCliente;
        }

        public int Id { get; set; }
        public int NumeroCartao { get; set; }
        public string NomeCliente { get; set; }


    }
}