using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class trocadewebservice4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelos");

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
                name: "Modelo");

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModelosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarroIdVeiculo = table.Column<int>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    MotoIdVeiculo = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModelosId);
                    table.ForeignKey(
                        name: "FK_Modelos_CARRO_CarroIdVeiculo",
                        column: x => x.CarroIdVeiculo,
                        principalTable: "CARRO",
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
                name: "IX_Modelos_MotoIdVeiculo",
                table: "Modelos",
                column: "MotoIdVeiculo");
        }
    }
}
