using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class Mudancasbanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheArquivoFrequencia");

            migrationBuilder.AddColumn<int>(
                name: "Dia1",
                table: "Arquivos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dia2",
                table: "Arquivos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaDaSemana",
                table: "Arquivos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FrequenciaExecucaoId",
                table: "Arquivos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Arquivos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos",
                column: "FrequenciaExecucaoId");

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

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Dia1",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Dia2",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "DiaDaSemana",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Arquivos");

            migrationBuilder.CreateTable(
                name: "DetalheArquivoFrequencia",
                columns: table => new
                {
                    ArquivoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FrequenciaExecucaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dia1 = table.Column<int>(type: "int", nullable: true),
                    Dia2 = table.Column<int>(type: "int", nullable: true),
                    DiaDaSemana = table.Column<string>(type: "varchar(100)", nullable: true),
                    Horario = table.Column<string>(type: "varchar(100)", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheArquivoFrequencia", x => new { x.ArquivoId, x.FrequenciaExecucaoId });
                    table.ForeignKey(
                        name: "FK_DetalheArquivoFrequencia_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalheArquivoFrequencia_FrequenciaExecucao_FrequenciaExecucaoId",
                        column: x => x.FrequenciaExecucaoId,
                        principalTable: "FrequenciaExecucao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalheArquivoFrequencia_ArquivoId",
                table: "DetalheArquivoFrequencia",
                column: "ArquivoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalheArquivoFrequencia_FrequenciaExecucaoId",
                table: "DetalheArquivoFrequencia",
                column: "FrequenciaExecucaoId");
        }
    }
}
