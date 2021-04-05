using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class Incluindomaiscamposnaentidadefrequencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dia1",
                table: "FrequenciaExecucao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dia2",
                table: "FrequenciaExecucao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DiaDaSemana",
                table: "FrequenciaExecucao",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "FrequenciaExecucao",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia1",
                table: "FrequenciaExecucao");

            migrationBuilder.DropColumn(
                name: "Dia2",
                table: "FrequenciaExecucao");

            migrationBuilder.DropColumn(
                name: "DiaDaSemana",
                table: "FrequenciaExecucao");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "FrequenciaExecucao");
        }
    }
}
