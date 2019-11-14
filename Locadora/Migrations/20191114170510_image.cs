using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "MOTO",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "CARRO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "MOTO");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "CARRO");
        }
    }
}
