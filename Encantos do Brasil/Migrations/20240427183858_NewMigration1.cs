using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class NewMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegiaoId",
                table: "Estados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegiaoId",
                table: "Cidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_RegiaoId",
                table: "Estados",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_RegiaoId",
                table: "Cidades",
                column: "RegiaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_RegioesPais_RegiaoId",
                table: "Cidades",
                column: "RegiaoId",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_RegioesPais_RegiaoId",
                table: "Estados",
                column: "RegiaoId",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_RegioesPais_RegiaoId",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_RegioesPais_RegiaoId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Estados_RegiaoId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_RegiaoId",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Cidades");
        }
    }
}
