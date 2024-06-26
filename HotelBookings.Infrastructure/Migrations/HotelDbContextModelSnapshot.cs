﻿// <auto-generated />
using System;
using HotelBookings.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBookings.Infrastructure.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelBookings.Core.Entities.AvaliacaoDoCliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DataDaAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDDoCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDDoHotel")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AvaliacoesDoCliente", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.EventoDeDominio", b =>
                {
                    b.Property<string>("TipoDeEvento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DadosRelevantes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("TipoDeEvento");

                    b.ToTable("EventosDeDominio", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Hotels", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.InformacoesDePagamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataEHoraDoPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDDaReserva")
                        .HasColumnType("int");

                    b.Property<string>("MetodoDePagamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StatusDoPagamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("InformacoesDePagamento", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Quarto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDoQuarto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PrecoPorNoite")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoDeQuarto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("Quartos", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Reserva", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDDoCliente")
                        .HasColumnType("int");

                    b.Property<int>("IDDoQuarto")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDeHospedes")
                        .HasColumnType("int");

                    b.Property<string>("StatusDaReserva")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("IDDoQuarto");

                    b.ToTable("Reservas", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.ServicoAdicional", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NomeDoServico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("PrecoAdicional")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("ServicosAdicionais", (string)null);
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Quarto", b =>
                {
                    b.HasOne("HotelBookings.Core.Entities.Hotel", null)
                        .WithMany("Quartos")
                        .HasForeignKey("HotelID");
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Reserva", b =>
                {
                    b.HasOne("HotelBookings.Core.Entities.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBookings.Core.Entities.Quarto", "Quarto")
                        .WithMany("Reservas")
                        .HasForeignKey("IDDoQuarto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Hotel", b =>
                {
                    b.Navigation("Quartos");
                });

            modelBuilder.Entity("HotelBookings.Core.Entities.Quarto", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
