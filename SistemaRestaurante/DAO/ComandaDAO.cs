﻿using Microsoft.EntityFrameworkCore;
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

        public IList<Comanda> ListarPorMesa(int mesaId)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Comandas.Where(c => c.MesaId == mesaId).ToList();
            }
        }

        public IList<Comanda> ListarSemMesa()
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Comandas.Where(c => c.MesaId == null).ToList();
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
                
                contexto.Comandas.Update(comanda);
                contexto.SaveChanges();
            }
        }

        public void Excluir(int numeroComanda)
        {
            using (var contexto = new RestauranteContext())
            {
                contexto.Comandas.Remove(contexto.Comandas.FirstOrDefault(c => c.Numero == numeroComanda));
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

        public Comanda BuscaPorNumero(int numeroComanda)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Comandas.FirstOrDefault(c => c.Numero == numeroComanda);
            }
        }
    }
}