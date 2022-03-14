﻿// <auto-generated />
using System;
using Jose_Gonzalez_Ap1_p2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jose_Gonzalez_Ap1_p2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Jose_Gonzalez_Ap1_p2.Entidades.EntradasEmpacados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Producto")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EntradasEmpacados");
                });

            modelBuilder.Entity("Jose_Gonzalez_Ap1_p2.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FechaCaducidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ganancia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Peso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Precio")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorInventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Jose_Gonzalez_Ap1_p2.Entidades.ProductosDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cantidad")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ExistenciaEmpaque")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Presentacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("ProductosDetalles");
                });

            modelBuilder.Entity("Jose_Gonzalez_Ap1_p2.Entidades.ProductosDetalles", b =>
                {
                    b.HasOne("Jose_Gonzalez_Ap1_p2.Entidades.Productos", null)
                        .WithMany("ProductosDetalles")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Jose_Gonzalez_Ap1_p2.Entidades.Productos", b =>
                {
                    b.Navigation("ProductosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
