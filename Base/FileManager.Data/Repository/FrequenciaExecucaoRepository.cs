using FileManager.Business.Interfaces;
using FileManager.Business.Models;
using FileManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Data.Repository
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
