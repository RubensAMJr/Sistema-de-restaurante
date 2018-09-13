using Microsoft.EntityFrameworkCore;
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
                contexto.Mesas.Update(mesa);
                contexto.SaveChanges();
            }
        }

        public void Excluir(int numeroMesa)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Mesas.Remove(contexto.Mesas.FirstOrDefault(m => m.Numero == numeroMesa));
                contexto.SaveChanges();
                

            }
        }

        public Mesa BuscaPorNumero(int numeroMesa)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Mesas.FirstOrDefault(m => m.Numero == numeroMesa);
            }
        }
    }
}