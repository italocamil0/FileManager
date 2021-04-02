using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Data.Migrations
{
    public partial class Alteracaocampodivisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Divisor",
                table: "Arquivos",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Divisor",
                table: "Arquivos",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }
    }
}
