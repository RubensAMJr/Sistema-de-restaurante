
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public String Cargo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int NumeroPedidos { get; set; }

        public Usuario(string cargo, string nome, string login, string senha)
        {
            Cargo = cargo;
            Nome = nome;
            Login = login;
            Senha = senha;
        }
    }
}

