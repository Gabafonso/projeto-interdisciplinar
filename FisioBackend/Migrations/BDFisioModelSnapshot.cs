﻿// <auto-generated />
using FisioBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FisioBackend.Migrations
{
    [DbContext(typeof(BDFisio))]
    partial class BDFisioModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FisioBackend.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("HoraFim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("FisioBackend.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DataPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataVenc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormaPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("ValorPag")
                        .HasColumnType("real");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("FisioBackend.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("FisioBackend.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cronograma")
                        .HasColumnType("int");

                    b.Property<string>("FormaPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("TipoServicoId")
                        .HasColumnType("int");

                    b.Property<float>("ValorServ")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("FisioBackend.Models.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposServico");
                });

            modelBuilder.Entity("FisioBackend.Models.Cliente", b =>
                {
                    b.HasBaseType("FisioBackend.Models.Pessoa");

                    b.Property<float>("Renda")
                        .HasColumnType("real");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("FisioBackend.Models.Funcionario", b =>
                {
                    b.HasBaseType("FisioBackend.Models.Pessoa");

                    b.Property<string>("Especialidade")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("FisioBackend.Models.Cliente", b =>
                {
                    b.HasOne("FisioBackend.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("FisioBackend.Models.Cliente", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FisioBackend.Models.Funcionario", b =>
                {
                    b.HasOne("FisioBackend.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("FisioBackend.Models.Funcionario", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
