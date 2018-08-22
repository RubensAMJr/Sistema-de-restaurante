using Microsoft.EntityFrameworkCore;
using SistemaRestaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaRestaurante
{ 
    public class RestauranteContext : DbContext 
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<MesaComanda> MesasComandas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestauranteDb;Trusted_Connection=true;");
           
        }

       

        
        


    }
}