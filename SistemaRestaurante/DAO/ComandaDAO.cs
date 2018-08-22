using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class ComandaDAO
    {
        public void Adiciona(Comanda comanda)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Comandas.Add(comanda);
                contexto.SaveChanges();
            }
        }

        public IList<Comanda> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Comandas.ToList();


            }

        }

        public void Atualizar(Comanda comanda)
        {

            using (var contexto = new RestauranteContext())
            {
                Comanda atualizado = Listar().Where(p => p.ComandaId == comanda.ComandaId).FirstOrDefault();
                atualizado = comanda;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Comanda comanda)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Comandas.Remove(comanda);
                contexto.SaveChanges();

            }
        }

        public Comanda BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Comandas.Find(id);
            }
        }
    }
}