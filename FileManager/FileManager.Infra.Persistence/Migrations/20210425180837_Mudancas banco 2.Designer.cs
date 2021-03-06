// <auto-generated />
using System;
using FileManager.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FileManager.Infra.Persistence.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20210425180837_Mudancas banco 2")]
    partial class Mudancasbanco2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FileManager.Core.Application.Entities.Arquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Dia1")
                        .HasColumnType("int");

                    b.Property<int?>("Dia2")
                        .HasColumnType("int");

                    b.Property<string>("DiaDaSemana")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Divisor")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Esquema")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("FrequenciaExecucaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Horario")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Posicional")
                        .HasColumnType("bit");

                    b.Property<Guid>("PrefixoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tabela")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("FrequenciaExecucaoId");

                    b.HasIndex("PrefixoId");

                    b.HasIndex("UserId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.Campo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArquivoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ArquivoId");

                    b.ToTable("Campo");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.FrequenciaExecucao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Frequencia")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FrequenciaExecucao");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.Prefixo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Prefixos");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.User.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.Arquivo", b =>
                {
                    b.HasOne("FileManager.Core.Application.Entities.FrequenciaExecucao", "FrequenciaExecucao")
                        .WithMany()
                        .HasForeignKey("FrequenciaExecucaoId")
                        .IsRequired();

                    b.HasOne("FileManager.Core.Application.Entities.Prefixo", "Prefixo")
                        .WithMany("Arquivo")
                        .HasForeignKey("PrefixoId")
                        .IsRequired();

                    b.HasOne("FileManager.Core.Application.Entities.User.ApplicationUser", "User")
                        .WithMany("Arquivos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FileManager.Core.Application.Entities.Campo", b =>
                {
                    b.HasOne("FileManager.Core.Application.Entities.Arquivo", "Arquivo")
                        .WithMany("Campos")
                        .HasForeignKey("ArquivoId");
                });
#pragma warning restore 612, 618
        }
    }
}
