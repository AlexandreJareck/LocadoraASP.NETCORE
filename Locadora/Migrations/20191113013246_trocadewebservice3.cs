using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class trocadewebservice3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Modelos_ModelosIdVeiculo",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Modelos_ModelosIdVeiculo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "AnoModelo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "CodigoFipe",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "IdMarca",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "IdModelo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "IdentVeiculo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "MesReferencia",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "ModelosIdVeiculo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "TipoVeiculo",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "ValorPorDia",
                table: "Modelos");

            migrationBuilder.DropColumn(
                name: "ValorPorHora",
                table: "Modelos");

            migrationBuilder.RenameColumn(
                name: "IdVeiculo",
                table: "Modelos",
                newName: "ModelosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelosId",
                table: "Modelos",
                newName: "IdVeiculo");

            migrationBuilder.AddColumn<int>(
                name: "AnoModelo",
                table: "Modelos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoFipe",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMarca",
                table: "Modelos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdModelo",
                table: "Modelos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdentVeiculo",
                table: "Modelos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MesReferencia",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelosIdVeiculo",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Modelos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoVeiculo",
                table: "Modelos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "Modelos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValorPorDia",
                table: "Modelos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorPorHora",
                table: "Modelos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_ModelosIdVeiculo",
                table: "Modelos",
                column: "ModelosIdVeiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Modelos_ModelosIdVeiculo",
                table: "Modelos",
                column: "ModelosIdVeiculo",
                principalTable: "Modelos",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
