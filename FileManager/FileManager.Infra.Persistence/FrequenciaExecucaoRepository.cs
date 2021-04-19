using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.Infra.Persistence
{
    public class FrequenciaExecucaoRepository : Repository<FrequenciaExecucao>, IFrequenciaExecucaoRepository
    {
        public FrequenciaExecucaoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<FrequenciaExecucao>> ObterFrequenciasExecucao()
        {
            return await Db.FrequenciaExecucao.AsNoTracking().ToListAsync();
        }
    }
}
