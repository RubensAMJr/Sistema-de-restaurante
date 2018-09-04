﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaRestaurante;

namespace SistemaRestaurante.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20180830164750_ItemPedido")]
    partial class ItemPedido
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaRestaurante.Models.Cartao", b =>
                {
                    b.Property<int>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCliente");

                    b.Property<int>("NumeroCartao");

                    b.HasKey("CartaoId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Comanda", b =>
                {
                    b.Property<int>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MesaId");

                    b.Property<string>("Numero");

                    b.HasKey("ComandaId");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.ItemPedido", b =>
                {
                    b.Property<int>("ItemPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Entregue");

                    b.Property<string>("Observacao");

                    b.Property<int>("PedidoId");

                    b.Property<int?>("ProdutoId");

                    b.HasKey("ItemPedidoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Numero");

                    b.HasKey("MesaId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComandaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("UsuarioId");

                    b.Property<double>("ValorTotal");

                    b.HasKey("PedidoId");

                    b.HasIndex("ComandaId")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<bool>("EstaEmFalta");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.ItemPedido", b =>
                {
                    b.HasOne("SistemaRestaurante.Models.Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SistemaRestaurante.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Pedido", b =>
                {
                    b.HasOne("SistemaRestaurante.Models.Comanda")
                        .WithOne("Pedido")
                        .HasForeignKey("SistemaRestaurante.Models.Pedido", "ComandaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}