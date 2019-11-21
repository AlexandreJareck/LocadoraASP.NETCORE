using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class addattVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "MOTO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorMensal",
                table: "MOTO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "CARRO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorMensal",
                table: "CARRO",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "ValorMensal",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "ValorMensal",
                table: "CARRO");
        }
    }
}
