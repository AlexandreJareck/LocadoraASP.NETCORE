using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARRO",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    AnoModelo = table.Column<int>(nullable: false),
                    Combustivel = table.Column<string>(nullable: true),
                    CodigoFipe = table.Column<string>(nullable: true),
                    MesReferencia = table.Column<string>(nullable: true),
                    TipoVeiculo = table.Column<int>(nullable: false),
                    IdMarca = table.Column<string>(nullable: true),
                    IdModelo = table.Column<string>(nullable: true),
                    IdentVeiculo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    ValorPorDia = table.Column<double>(nullable: false),
                    ValorPorHora = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRO", x => x.IdVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Cnh = table.Column<string>(nullable: true),
                    CategoriaCnh = table.Column<string>(nullable: true),
                    PossuiReserva = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    MotoId = table.Column<int>(nullable: false),
                    CarroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "MOTO",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    AnoModelo = table.Column<int>(nullable: false),
                    Combustivel = table.Column<string>(nullable: true),
                    CodigoFipe = table.Column<string>(nullable: true),
                    MesReferencia = table.Column<string>(nullable: true),
                    TipoVeiculo = table.Column<int>(nullable: false),
                    IdMarca = table.Column<string>(nullable: true),
                    IdModelo = table.Column<string>(nullable: true),
                    IdentVeiculo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    ValorPorDia = table.Column<double>(nullable: false),
                    ValorPorHora = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTO", x => x.IdVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "Modelo",
                columns: table => new
                {
                    ModeloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CarroIdVeiculo = table.Column<int>(nullable: true),
                    MotoIdVeiculo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.ModeloId);
                    table.ForeignKey(
                        name: "FK_Modelo_CARRO_CarroIdVeiculo",
                        column: x => x.CarroIdVeiculo,
                        principalTable: "CARRO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modelo_MOTO_MotoIdVeiculo",
                        column: x => x.MotoIdVeiculo,
                        principalTable: "MOTO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_CarroIdVeiculo",
                table: "Modelo",
                column: "CarroIdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_MotoIdVeiculo",
                table: "Modelo",
                column: "MotoIdVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "Modelo");

            migrationBuilder.DropTable(
                name: "CARRO");

            migrationBuilder.DropTable(
                name: "MOTO");
        }
    }
}
