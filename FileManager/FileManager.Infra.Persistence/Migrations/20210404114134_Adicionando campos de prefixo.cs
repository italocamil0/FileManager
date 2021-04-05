using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class Adicionandocamposdeprefixo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefixo",
                table: "Arquivos");

            migrationBuilder.AddColumn<Guid>(
                name: "PrefixoId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Prefixos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefixos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos",
                column: "PrefixoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Prefixos_PrefixoId",
                table: "Arquivos",
                column: "PrefixoId",
                principalTable: "Prefixos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Prefixos_PrefixoId",
                table: "Arquivos");

            migrationBuilder.DropTable(
                name: "Prefixos");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "PrefixoId",
                table: "Arquivos");

            migrationBuilder.AddColumn<string>(
                name: "Prefixo",
                table: "Arquivos",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
