using FileManager.Core.Application.DTOs;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;

namespace FileManager.Infra.Persistence
{
    public class ArquivosRepository : Repository<Arquivo>, IArquivosRepository
    {
        public ArquivosRepository(MeuDbContext contexto) : base(contexto)
        {
        }
    }
}
