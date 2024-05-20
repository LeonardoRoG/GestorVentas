using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorVentas.Database.Migrations
{
    /// <inheritdoc />
    public partial class EmpleadoConJefe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdJefe",
                table: "Empleado",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdJefe",
                table: "Empleado",
                column: "IdJefe");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Empleado_IdJefe",
                table: "Empleado",
                column: "IdJefe",
                principalTable: "Empleado",
                principalColumn: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Empleado_IdJefe",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_IdJefe",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdJefe",
                table: "Empleado");
        }
    }
}
