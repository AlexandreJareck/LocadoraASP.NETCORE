using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class trocadewebservice2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
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
                    IdMarca = table.Column<int>(nullable: false),
                    IdModelo = table.Column<int>(nullable: false),
                    IdentVeiculo = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    ValorPorDia = table.Column<double>(nullable: false),
                    ValorPorHora = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CarroIdVeiculo = table.Column<int>(nullable: true),
                    ModelosIdVeiculo = table.Column<int>(nullable: true),
                    MotoIdVeiculo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.IdVeiculo);
                    table.ForeignKey(
                        name: "FK_Modelos_CARRO_CarroIdVeiculo",
                        column: x => x.CarroIdVeiculo,
                        principalTable: "CARRO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modelos_Modelos_ModelosIdVeiculo",
                        column: x => x.ModelosIdVeiculo,
                        principalTable: "Modelos",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modelos_MOTO_MotoIdVeiculo",
                        column: x => x.MotoIdVeiculo,
                        principalTable: "MOTO",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_CarroIdVeiculo",
                table: "Modelos",
                column: "CarroIdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_ModelosIdVeiculo",
                table: "Modelos",
                column: "ModelosIdVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MotoIdVeiculo",
                table: "Modelos",
                column: "MotoIdVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");
        }
    }
}
