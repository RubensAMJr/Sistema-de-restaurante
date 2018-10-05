using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Produto
    {
        public Produto(string nome, double preco, string descricao, bool estaEmFalta)
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            EstaEmFalta = estaEmFalta;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public bool EstaEmFalta { get; set; }
        public int numeroVendas { get; set; }
    }


}