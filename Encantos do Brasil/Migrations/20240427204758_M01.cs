using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encantos_do_Brasil.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IdUsuario",
                table: "Preferencias");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "RegiaoId",
                table: "Cidades");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_IdHotel",
                table: "Telefones",
                column: "IdHotel");

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

            migrationBuilder.CreateIndex(
                name: "IX_PontosTuristicos_IdCidade",
                table: "PontosTuristicos",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Hoteis_IdCidade",
                table: "Hoteis",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdRegiao",
                table: "Estados",
                column: "IdRegiao");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_IdRegiao",
                table: "Cidades",
                column: "IdRegiao");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_IdEstado",
                table: "Cidades",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_RegioesPais_IdRegiao",
                table: "Cidades",
                column: "IdRegiao",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_RegioesPais_IdRegiao",
                table: "Estados",
                column: "IdRegiao",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Hoteis_Cidades_IdCidade",
                table: "Hoteis",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosTuristicos_Cidades_IdCidade",
                table: "PontosTuristicos",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferencias_Cidades_IdCidade",
                table: "Preferencias",
                column: "IdCidade",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferencias_Hoteis_IdHotel",
                table: "Preferencias",
                column: "IdHotel",
                principalTable: "Hoteis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferencias_PontosTuristicos_IdPontoTuristico",
                table: "Preferencias",
                column: "IdPontoTuristico",
                principalTable: "PontosTuristicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Hoteis_IdHotel",
                table: "Telefones",
                column: "IdHotel",
                principalTable: "Hoteis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_IdEstado",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_RegioesPais_IdRegiao",
                table: "Cidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_RegioesPais_IdRegiao",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Hoteis_Cidades_IdCidade",
                table: "Hoteis");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosTuristicos_Cidades_IdCidade",
                table: "PontosTuristicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferencias_Cidades_IdCidade",
                table: "Preferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferencias_Hoteis_IdHotel",
                table: "Preferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferencias_PontosTuristicos_IdPontoTuristico",
                table: "Preferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Hoteis_IdHotel",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_IdHotel",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Preferencias_IdCidade",
                table: "Preferencias");

            migrationBuilder.DropIndex(
                name: "IX_Preferencias_IdHotel",
                table: "Preferencias");

            migrationBuilder.DropIndex(
                name: "IX_Preferencias_IdPontoTuristico",
                table: "Preferencias");

            migrationBuilder.DropIndex(
                name: "IX_PontosTuristicos_IdCidade",
                table: "PontosTuristicos");

            migrationBuilder.DropIndex(
                name: "IX_Hoteis_IdCidade",
                table: "Hoteis");

            migrationBuilder.DropIndex(
                name: "IX_Estados_IdRegiao",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_IdEstado",
                table: "Cidades");

            migrationBuilder.DropIndex(
                name: "IX_Cidades_IdRegiao",
                table: "Cidades");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Preferencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_RegioesPais_RegiaoId",
                table: "Estados",
                column: "RegiaoId",
                principalTable: "RegioesPais",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
