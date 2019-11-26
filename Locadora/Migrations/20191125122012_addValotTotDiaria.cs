using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class addValotTotDiaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorTotalDiaria",
                table: "RESERVA",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalDiaria",
                table: "RESERVA");
        }
    }
}
