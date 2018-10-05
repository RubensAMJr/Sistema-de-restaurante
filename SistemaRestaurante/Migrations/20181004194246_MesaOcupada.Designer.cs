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
    [Migration("20181004194246_MesaOcupada")]
    partial class MesaOcupada
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCliente");

                    b.Property<int>("NumeroCartao");

                    b.HasKey("Id");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MesaId");

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<bool>("Entregue");

                    b.Property<string>("Observacao");

                    b.Property<int>("PedidoId");

                    b.Property<int?>("ProdutoId");

                    b.HasKey("Id");

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

                    b.Property<bool>("Ocupada");

                    b.HasKey("MesaId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComandaId");

                    b.Property<int>("Numero");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId")
                        .IsUnique()
                        .HasFilter("[ComandaId] IS NOT NULL");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<bool>("EstaEmFalta");

                    b.Property<string>("Nome");

                    b.Property<double>("Preco");

                    b.Property<int>("numeroVendas");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SistemaRestaurante.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

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
                        .HasForeignKey("SistemaRestaurante.Models.Pedido", "ComandaId");
                });
#pragma warning restore 612, 618
        }
    }
}
