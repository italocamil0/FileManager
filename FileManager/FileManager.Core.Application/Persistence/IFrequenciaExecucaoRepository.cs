using FileManager.Core.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Persistence
{
    public interface IFrequenciaExecucaoRepository : IRepository<FrequenciaExecucao>
    {
        Task<IEnumerable<FrequenciaExecucao>> ObterFrequenciasExecucao();
    }
}
