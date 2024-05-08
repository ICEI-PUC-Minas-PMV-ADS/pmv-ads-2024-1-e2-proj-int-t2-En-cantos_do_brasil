using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferencias");

            migrationBuilder.AddColumn<int>(
                name: "Preferencia",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Preferencia",
                table: "Cidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    IdPontoTuristico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoritos_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Hoteis_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hoteis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_PontosTuristicos_IdPontoTuristico",
                        column: x => x.IdPontoTuristico,
                        principalTable: "PontosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdCidade",
                table: "Favoritos",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdHotel",
                table: "Favoritos",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_IdPontoTuristico",
                table: "Favoritos",
                column: "IdPontoTuristico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropColumn(
                name: "Preferencia",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "Preferencia",
                table: "Cidades");

            migrationBuilder.CreateTable(
                name: "Preferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    IdPontoTuristico = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferencias_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferencias_Hoteis_IdHotel",
                        column: x => x.IdHotel,
                        principalTable: "Hoteis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferencias_PontosTuristicos_IdPontoTuristico",
                        column: x => x.IdPontoTuristico,
                        principalTable: "PontosTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_IdCidade",
                table: "Preferencias",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_IdHotel",
                table: "Preferencias",
                column: "IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencias_IdPontoTuristico",
                table: "Preferencias",
                column: "IdPontoTuristico");
        }
    }
}
