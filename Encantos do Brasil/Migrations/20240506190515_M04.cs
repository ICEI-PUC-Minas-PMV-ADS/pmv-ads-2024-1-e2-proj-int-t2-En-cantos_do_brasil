using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Usuarios",
                newName: "Preferencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preferencia",
                table: "Usuarios",
                newName: "Perfil");

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
