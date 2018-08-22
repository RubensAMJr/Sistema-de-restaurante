using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class MesasDAO
    {
        public void Adiciona(Mesa mesa)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Mesas.Add(mesa);
                contexto.SaveChanges();
            }
        }

        public IList<Mesa> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Mesas.ToList();


            }

        }

        public void Atualizar(Mesa mesa)
        {

            using (var contexto = new RestauranteContext())
            {
                Mesa atualizado = Listar().Where(m => m.MesaId == mesa.MesaId).FirstOrDefault();
                atualizado = mesa;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Mesa mesa)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Mesas.Remove(mesa);
                contexto.SaveChanges();

            }
        }

        public Mesa BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Mesas.Find(id);
            }
        }
    }
}