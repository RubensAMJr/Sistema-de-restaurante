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
                Usuario atualizado = Listar().Where(p => p.Id == usuario.Id).FirstOrDefault();
                atualizado = usuario;
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
    }
}