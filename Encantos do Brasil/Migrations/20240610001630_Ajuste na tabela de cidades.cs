using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class Ajustenatabeladecidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "TextosEstados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "TextosEstados");
        }
    }
}
