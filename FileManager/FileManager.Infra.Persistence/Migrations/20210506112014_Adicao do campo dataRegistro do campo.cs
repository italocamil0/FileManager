using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class AdicaodocampodataRegistrodocampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistro",
                table: "Campo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegistro",
                table: "Campo");
        }
    }
}
