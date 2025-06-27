using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaCabanasApp.Migrations
{
    /// <inheritdoc />
    public partial class SoporteImagenesPorCabana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabanaImagenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CabanaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagenUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabanaImagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabanaImagenes_Cabanas_CabanaId",
                        column: x => x.CabanaId,
                        principalTable: "Cabanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabanaImagenes_CabanaId",
                table: "CabanaImagenes",
                column: "CabanaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabanaImagenes");
        }
    }
}
