﻿// <auto-generated />
using System;
using GestorVentas.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorVentas.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240521142136_ModificacionTablaVehiculo")]
    partial class ModificacionTablaVehiculo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("GestorVentas.Domain.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("GestorVentas.Domain.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CUIT")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ciudad")
                        .HasColumnType("TEXT");

                    b.Property<string>("CondicionIVA")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int?>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("GestorVentas.Domain.DetalleOrden", b =>
                {
                    b.Property<int>("IdDetalleOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdOrden")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdDetalleOrden");

                    b.HasIndex("IdOrden");

                    b.HasIndex("IdProducto");

                    b.ToTable("DetalleOrden");
                });

            modelBuilder.Entity("GestorVentas.Domain.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdJefe")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdVehiculo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sueldo")
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdJefe");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("GestorVentas.Domain.Orden", b =>
                {
                    b.Property<int>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destino")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetodoEnvio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdOrden");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("GestorVentas.Domain.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Discontinuado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlImagen")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("GestorVentas.Domain.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CUIT")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Telefono")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("GestorVentas.Domain.Vehiculo", b =>
                {
                    b.Property<int>("IdVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Año")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Combustible")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Litros")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdVehiculo");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("GestorVentas.Domain.DetalleOrden", b =>
                {
                    b.HasOne("GestorVentas.Domain.Orden", "Orden")
                        .WithMany("DetallesOrdenes")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorVentas.Domain.Producto", "Producto")
                        .WithMany("DetallesOrdenes")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestorVentas.Domain.Empleado", b =>
                {
                    b.HasOne("GestorVentas.Domain.Empleado", "Jefe")
                        .WithMany("Subordinados")
                        .HasForeignKey("IdJefe");

                    b.HasOne("GestorVentas.Domain.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("IdVehiculo");

                    b.Navigation("Jefe");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("GestorVentas.Domain.Orden", b =>
                {
                    b.HasOne("GestorVentas.Domain.Cliente", "Cliente")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorVentas.Domain.Empleado", "Empleado")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("GestorVentas.Domain.Producto", b =>
                {
                    b.HasOne("GestorVentas.Domain.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorVentas.Domain.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("GestorVentas.Domain.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("GestorVentas.Domain.Cliente", b =>
                {
                    b.Navigation("Ordenes");
                });

            modelBuilder.Entity("GestorVentas.Domain.Empleado", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Subordinados");
                });

            modelBuilder.Entity("GestorVentas.Domain.Orden", b =>
                {
                    b.Navigation("DetallesOrdenes");
                });

            modelBuilder.Entity("GestorVentas.Domain.Producto", b =>
                {
                    b.Navigation("DetallesOrdenes");
                });

            modelBuilder.Entity("GestorVentas.Domain.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
