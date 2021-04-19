using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Infra.Persistence
{
    public class ArquivosRepository : Repository<Arquivo>, IArquivosRepository
    {
        public ArquivosRepository(MeuDbContext contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Arquivo>> ObterArquivosFrequenciasPrefixos()
        {


            return await Db.Arquivos.AsNoTracking().Include(p => p.Prefixo).Include(d => d.DetalheArquivoFrequencia).ThenInclude(cs=>cs.FrequenciasExecucao)
                .OrderBy(p => p.Tabela).ToListAsync();
        }

    }
}
