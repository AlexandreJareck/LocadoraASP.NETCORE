using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class newClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MOTO",
                newName: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "MOTO",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "MOTO",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CARRO",
                newName: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "CARRO",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "CARRO",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Ano_Modelo",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "MOTO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fipe_codigo",
                table: "MOTO",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "MOTO",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Ano_Modelo",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "CARRO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fipe_codigo",
                table: "CARRO",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "CARRO",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano_Modelo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Fipe_codigo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Ano_Modelo",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "Fipe_codigo",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "CARRO");

            migrationBuilder.RenameColumn(
                name: "veiculo",
                table: "MOTO",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MOTO",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MOTO",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "veiculo",
                table: "CARRO",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CARRO",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CARRO",
                newName: "Ano");
        }
    }
}
