using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infra.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrefixoId = table.Column<Guid>(nullable: false),
                    Tabela = table.Column<string>(type: "varchar(100)", nullable: true),
                    Esquema = table.Column<string>(type: "varchar(100)", nullable: true),
                    Posicional = table.Column<bool>(nullable: false),
                    Divisor = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(100)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivos_Prefixos_PrefixoId",
                        column: x => x.PrefixoId,
                        principalTable: "Prefixos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arquivos_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Tamanho = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ArquivoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campo_Arquivos_ArquivoId",
                        column: x => x.ArquivoId,
                        principalTable: "Arquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalheArquivoFrequencia",
                columns: table => new
                {
                    ArquivoId = table.Column<Guid>(nullable: false),
                    FrequenciaExecucaoId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    DiaDaSemana = table.Column<string>(type: "varchar(100)", nullable: true),
                    Dia1 = table.Column<int>(nullable: true),
                    Dia2 = table.Column<int>(nullable: true),
                    Horario = table.Column<string>(type: "varchar(100)", nullable: true)
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
                name: "IX_Arquivos_PrefixoId",
                table: "Arquivos",
                column: "PrefixoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_UserId",
                table: "Arquivos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Campo_ArquivoId",
                table: "Campo",
                column: "ArquivoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campo");

            migrationBuilder.DropTable(
                name: "DetalheArquivoFrequencia");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "FrequenciaExecucao");

            migrationBuilder.DropTable(
                name: "Prefixos");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
