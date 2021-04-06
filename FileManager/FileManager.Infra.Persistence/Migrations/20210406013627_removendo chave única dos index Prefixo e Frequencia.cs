using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class removendochaveúnicadosindexPrefixoeFrequencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos",
                column: "FrequenciaExecucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos",
                column: "PrefixoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_FrequenciaExecucaoId",
                table: "Arquivos",
                column: "FrequenciaExecucaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos",
                column: "PrefixoId",
                unique: true);
        }
    }
}
