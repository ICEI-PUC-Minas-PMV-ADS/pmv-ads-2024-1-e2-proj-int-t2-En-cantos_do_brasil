using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_RegioesPais_IdRegiao",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_IdRegiao",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "IdRegiao",
                table: "Cidades");

            migrationBuilder.AddColumn<int>(
                name: "Perfil",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "IdRegiao",
                table: "Cidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdRegiao",
                table: "Cidades",
                column: "IdRegiao");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_RegioesPais_IdRegiao",
                table: "Cidades",
                column: "IdRegiao",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
