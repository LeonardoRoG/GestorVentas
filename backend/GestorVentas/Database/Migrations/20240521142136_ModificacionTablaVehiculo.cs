using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentas.Database.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTablaVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Vehiculo",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Vehiculo");
        }
    }
}
