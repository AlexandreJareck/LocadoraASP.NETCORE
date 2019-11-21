using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class addClassReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RESERVA",
                columns: table => new
                {
                    IdReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataReserva = table.Column<DateTime>(nullable: false),
                    DataPrevisaoDevolucao = table.Column<DateTime>(nullable: false),
                    DataVeiculoDevolvido = table.Column<DateTime>(nullable: false),
                    ValorTotalReserva = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    CarroId = table.Column<int>(nullable: false),
                    MotoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVA", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_RESERVA_CARRO_CarroId",
                        column: x => x.CarroId,
                        principalTable: "CARRO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVA_CLIENTE_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVA_MOTO_MotoId",
                        column: x => x.MotoId,
                        principalTable: "MOTO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_CarroId",
                table: "RESERVA",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_ClienteId",
                table: "RESERVA",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_MotoId",
                table: "RESERVA",
                column: "MotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESERVA");
        }
    }
}
