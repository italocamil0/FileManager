using FileManager.Business.Interfaces;
using FileManager.Business.Models;
using FileManager.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Data.Repository
{
    public class ArquivoRepository : Repository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(MeuDbContext contexto) : base(contexto)
        {
        }
    }
}
