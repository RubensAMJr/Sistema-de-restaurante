using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.DAO
{
    public class PedidoDAO
    {
        public void Adiciona(Pedido pedido)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Pedidos.Add(pedido);
                contexto.SaveChanges();
            }
        }

        public IList<Pedido> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Pedidos.ToList();


            }

        }

        public void Atualizar(Pedido pedido)
        {

            using (var contexto = new RestauranteContext())
            {
                Pedido atualizado = Listar().Where(p => p.Id == pedido.Id).FirstOrDefault();
                atualizado = pedido;
                contexto.SaveChanges();
            }
        }

        public void Excluir(Pedido pedido)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Pedidos.Remove(pedido);
                contexto.SaveChanges();

            }
        }

        public Pedido BuscaPorId(int id)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Pedidos.Find(id);
            }
        }

    }
}