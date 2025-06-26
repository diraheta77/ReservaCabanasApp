using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaCabanasApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCabanaCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantidadPersonas",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Reservas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamasIndividuales",
                table: "Cabanas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CamasMatrimonial",
                table: "Cabanas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Cabanas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Cabanas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadPersonas",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "CamasIndividuales",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "CamasMatrimonial",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Cabanas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Cabanas");
        }
    }
}
