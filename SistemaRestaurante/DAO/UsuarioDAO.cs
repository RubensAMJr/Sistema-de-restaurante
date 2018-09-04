using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class UsuarioDAO
    {
        public void Adiciona(Usuario usuario)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }
        }

        public IList<Usuario> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Usuarios.ToList();


            }

        }

        public void Atualizar(Usuario usuario)
        {

            using (var contexto = new RestauranteContext())
            {
                contexto.Usuarios.Update(usuario);
                contexto.SaveChanges();
            }
        }

        public void Excluir(Usuario usuario)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Usuarios.Remove(usuario);
                contexto.SaveChanges();

            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public Usuario Busca(string usuario, string senha)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == usuario && u.Senha == senha);
            }
        }

        public String BuscaCargo(string usuario)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == usuario).Cargo;
            }
        }
    }
}