using Microsoft.EntityFrameworkCore;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class PedidoDAO
    {
        public void Adiciona(Pedido pedido)
        {
            using (var contexto = new RestauranteContext())
            {
                    contexto.Pedido.Add(pedido);
                    contexto.SaveChanges();
                
            }
        }

        public IList<Pedido> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Pedido.Include(Pedido => Pedido.Itens).ToList();
            }

        }

        public void Atualizar(Pedido pedido)
        {

            using (var contexto = new RestauranteContext())
            {
                contexto.Pedido.Update(pedido);
                contexto.SaveChanges();
            }
        }

        public void Excluir(Pedido pedido)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Pedido.Remove(pedido);
                contexto.SaveChanges();

            }
        }

        public Pedido BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Pedido.Find(id);
            }
        }

        public Pedido BuscaPorComanda(int comandaId)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Pedido.FirstOrDefault(p => p.ComandaId == comandaId);
            }
        }
    }
}