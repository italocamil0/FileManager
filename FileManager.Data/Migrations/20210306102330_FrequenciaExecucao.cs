using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Data.Migrations
{
    public partial class FrequenciaExecucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequenciaExecucao",
                table: "Arquivos");

            migrationBuilder.AddColumn<Guid>(
                name: "FrequenciaExecucaoId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FrequenciaExecucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Frequencia = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequenciaExecucao", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos",
                column: "FrequenciaExecucaoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_FrequenciaExecucao_FrequenciaExecucaoId",
                table: "Arquivos",
                column: "FrequenciaExecucaoId",
                principalTable: "FrequenciaExecucao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_FrequenciaExecucao_FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropTable(
                name: "FrequenciaExecucao");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "FrequenciaExecucao",
                table: "Arquivos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
