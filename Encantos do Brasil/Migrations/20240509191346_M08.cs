using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class M08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoImagem",
                table: "ImagensCidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImagensEstados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dados = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoConteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoImagem = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensEstados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensEstados_Estados_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensEstados_IdCidade",
                table: "ImagensEstados",
                column: "IdCidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensEstados");

            migrationBuilder.DropColumn(
                name: "TipoImagem",
                table: "ImagensCidades");
        }
    }
}
