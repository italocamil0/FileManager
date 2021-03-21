using FileManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FileManager.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Arquivo> Arquivos { get; set; }

        public DbSet<FrequenciaExecucao> FrequenciaExecucao { get; set; }

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
        }
    }
}
