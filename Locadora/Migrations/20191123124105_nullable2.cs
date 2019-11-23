using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class nullable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_CARRO_CarroId",
                table: "RESERVA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_CLIENTE_ClienteId",
                table: "RESERVA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_MOTO_MotoId",
                table: "RESERVA");

            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "RESERVA",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "RESERVA",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "RESERVA",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_CARRO_CarroId",
                table: "RESERVA",
                column: "CarroId",
                principalTable: "CARRO",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_CLIENTE_ClienteId",
                table: "RESERVA",
                column: "ClienteId",
                principalTable: "CLIENTE",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_MOTO_MotoId",
                table: "RESERVA",
                column: "MotoId",
                principalTable: "MOTO",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_CARRO_CarroId",
                table: "RESERVA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_CLIENTE_ClienteId",
                table: "RESERVA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESERVA_MOTO_MotoId",
                table: "RESERVA");

            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "RESERVA",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "RESERVA",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "RESERVA",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_CARRO_CarroId",
                table: "RESERVA",
                column: "CarroId",
                principalTable: "CARRO",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_CLIENTE_ClienteId",
                table: "RESERVA",
                column: "ClienteId",
                principalTable: "CLIENTE",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVA_MOTO_MotoId",
                table: "RESERVA",
                column: "MotoId",
                principalTable: "MOTO",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
