using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class AttClassVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdModelo",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentVeiculo",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdModelo",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentVeiculo",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "IdModelo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "IdentVeiculo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "IdModelo",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "IdentVeiculo",
                table: "CARRO");
        }
    }
}
