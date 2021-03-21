using FileManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Data.Mappings
{
    public class ArquivoMappin : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Tabela)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Esquema)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Prefixo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Arquivos");
        }
    }
}
