using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class AddTablePagament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesReferencia",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "MesReferencia",
                table: "CARRO");

            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Credito = table.Column<bool>(nullable: true),
                    Debito = table.Column<bool>(nullable: true),
                    Dinheiro = table.Column<bool>(nullable: true),
                    NroCartao = table.Column<string>(nullable: true),
                    ClienteIdCliente = table.Column<int>(nullable: true),
                    ReservaIdReserva = table.Column<int>(nullable: true),
                    DtVeicDevolvido = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ValorTotalReserva = table.Column<double>(nullable: false),
                    ValorPagamento = table.Column<double>(nullable: false),
                    ValorTroco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_CLIENTE_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "CLIENTE",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_RESERVA_ReservaIdReserva",
                        column: x => x.ReservaIdReserva,
                        principalTable: "RESERVA",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_ClienteIdCliente",
                table: "PAGAMENTO",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_ReservaIdReserva",
                table: "PAGAMENTO",
                column: "ReservaIdReserva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGAMENTO");

            migrationBuilder.AddColumn<string>(
                name: "MesReferencia",
                table: "MOTO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MesReferencia",
                table: "CARRO",
                nullable: true);
        }
    }
}
