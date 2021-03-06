using FileManager.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager.Infra.Persistence.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }

        public DbSet<FrequenciaExecucao> FrequenciaExecucao { get; set; }

        public DbSet<Prefixo> Prefixos { get; set; }

        public DbSet<Campo> Campo { get; set; }

        //public DbSet<DetalheArquivoFrequencia> DetalheArquivoFrequencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Arquivo>()
                .HasOne(po => po.User)
                .WithMany(a => a.Arquivos)
                .HasForeignKey(po => po.UserId);

            modelBuilder.Entity<Campo>()
                .Property(c => c.DataRegistro)
                .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<DetalheArquivoFrequencia>().HasIndex(s => s.ArquivoId).IsUnique(true);
            //modelBuilder.Entity<DetalheArquivoFrequencia>().HasIndex(s => s.FrequenciaExecucaoId).IsUnique(true);

            //modelBuilder.Entity<DetalheArquivoFrequencia>().HasKey(vf => new { vf.ArquivoId, vf.FrequenciaExecucaoId });
        }
    }
}
