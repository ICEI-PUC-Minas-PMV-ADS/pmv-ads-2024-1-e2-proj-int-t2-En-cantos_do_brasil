using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class ajustenacolunadeforeignkeydeimagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagensEstados_Estados_IdCidade",
                table: "ImagensEstados");

            migrationBuilder.DropIndex(
                name: "IX_ImagensEstados_IdCidade",
                table: "ImagensEstados");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "ImagensEstados");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentarioss = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Cidades_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensEstados_IdEstado",
                table: "ImagensEstados",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdCidade",
                table: "Comentarios",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagensEstados_Estados_IdEstado",
                table: "ImagensEstados",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagensEstados_Estados_IdEstado",
                table: "ImagensEstados");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_ImagensEstados_IdEstado",
                table: "ImagensEstados");

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "ImagensEstados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagensEstados_IdCidade",
                table: "ImagensEstados",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagensEstados_Estados_IdCidade",
                table: "ImagensEstados",
                column: "IdCidade",
                principalTable: "Estados",
                principalColumn: "Id");
        }
    }
}
