using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class trocadewebservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "veiculo",
                table: "MOTO",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MOTO",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "MOTO",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MOTO",
                newName: "MesReferencia");

            migrationBuilder.RenameColumn(
                name: "Fipe_codigo",
                table: "MOTO",
                newName: "CodigoFipe");

            migrationBuilder.RenameColumn(
                name: "Ano_Modelo",
                table: "MOTO",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "veiculo",
                table: "CARRO",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CARRO",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "CARRO",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CARRO",
                newName: "MesReferencia");

            migrationBuilder.RenameColumn(
                name: "Fipe_codigo",
                table: "CARRO",
                newName: "CodigoFipe");

            migrationBuilder.RenameColumn(
                name: "Ano_Modelo",
                table: "CARRO",
                newName: "Codigo");

            migrationBuilder.AddColumn<int>(
                name: "AnoModelo",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoVeiculo",
                table: "MOTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnoModelo",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoVeiculo",
                table: "CARRO",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoModelo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "TipoVeiculo",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "AnoModelo",
                table: "CARRO");

            migrationBuilder.DropColumn(
                name: "TipoVeiculo",
                table: "CARRO");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "MOTO",
                newName: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "MOTO",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "MOTO",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "MesReferencia",
                table: "MOTO",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CodigoFipe",
                table: "MOTO",
                newName: "Fipe_codigo");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "MOTO",
                newName: "Ano_Modelo");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "CARRO",
                newName: "veiculo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "CARRO",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "CARRO",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "MesReferencia",
                table: "CARRO",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CodigoFipe",
                table: "CARRO",
                newName: "Fipe_codigo");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "CARRO",
                newName: "Ano_Modelo");
        }
    }
}
