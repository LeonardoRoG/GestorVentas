using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentas.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    UrlImagen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "INTEGER", nullable: true),
                    CUIT = table.Column<int>(type: "INTEGER", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: false),
                    CondicionIVA = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CUIT = table.Column<int>(type: "INTEGER", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Año = table.Column<int>(type: "INTEGER", nullable: true),
                    Combustible = table.Column<int>(type: "INTEGER", nullable: false),
                    Litros = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.IdVehiculo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UrlImagen = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discontinuado = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdProveedor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "INTEGER", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Telefono = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Puesto = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Sueldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdVehiculo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Vehiculo_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "IdVehiculo");
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaOrden = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Destino = table.Column<string>(type: "TEXT", nullable: true),
                    MetodoEnvio = table.Column<string>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEmpleado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    IdOrden = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdOrden",
                table: "DetalleOrden",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdProducto",
                table: "DetalleOrden",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdVehiculo",
                table: "Empleado",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdCliente",
                table: "Orden",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdEmpleado",
                table: "Orden",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProveedor",
                table: "Producto",
                column: "IdProveedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
