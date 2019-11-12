using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class projetoatt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARRO",
                columns: table => new
                {
                    IdVeiculo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ano_Modelo = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true),
                    Preco = table.Column<string>(nullable: false),
                    Combustivel = table.Column<string>(nullable: true),
                    Fipe_codigo = table.Column<string>(nullable: true),
                    IdMarca = table.Column<int>(nullable: false),
                    IdModelo = table.Column<int>(nullable: false),
                    IdentVeiculo = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    ValorPorDia = table.Column<double>(nullable: false),
                    ValorPorHora = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: true)
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
                    Ano_Modelo = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    veiculo = table.Column<string>(nullable: true),
                    Preco = table.Column<string>(nullable: false),
                    Combustivel = table.Column<string>(nullable: true),
                    Fipe_codigo = table.Column<string>(nullable: true),
                    IdMarca = table.Column<int>(nullable: false),
                    IdModelo = table.Column<int>(nullable: false),
                    IdentVeiculo = table.Column<int>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: false),
                    ValorPorDia = table.Column<double>(nullable: false),
                    ValorPorHora = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTO", x => x.IdVeiculo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARRO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "MOTO");
        }
    }
}
