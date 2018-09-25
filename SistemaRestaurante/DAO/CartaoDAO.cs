using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante.DAO
{
    public class CartaoDAO
    {
        public void Adiciona(Cartao cartao)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Cartoes.Add(cartao);
                contexto.SaveChanges();
            }
        }

        public IList<Cartao> Listar()
        {
            using (var contexto = new RestauranteContext())
            {

                return contexto.Cartoes.ToList();


            }

        }

        public void Atualizar(Cartao cartao)
        {

            using (var contexto = new RestauranteContext())
            {
                contexto.Cartoes.Update(cartao);
                contexto.SaveChanges();
            }
        }

        public void Excluir(int numeroCartao)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Cartoes.Remove(contexto.Cartoes.FirstOrDefault(c => c.NumeroCartao == numeroCartao));
                contexto.SaveChanges();
            }
        }

        public Cartao BuscaPorNumero(int numeroCartao)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Cartoes.FirstOrDefault(c => c.NumeroCartao == numeroCartao);
            }
        }

        public Cartao BuscaPorNome(string nomeCliente)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Cartoes.FirstOrDefault(c => c.NomeCliente == nomeCliente);
            }
        }
    }
}