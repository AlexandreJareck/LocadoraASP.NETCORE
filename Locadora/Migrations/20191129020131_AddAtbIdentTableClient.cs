using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class AddAtbIdentTableClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "CLIENTE",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "CLIENTE",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Ident",
                table: "CLIENTE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ident",
                table: "CLIENTE");

            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "CLIENTE",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarroId",
                table: "CLIENTE",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
