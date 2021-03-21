using FileManager.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Business.Interfaces
{
    public interface IFrequenciaExecucaoRepository : IRepository<FrequenciaExecucao>
    {
        Task<IEnumerable<FrequenciaExecucao>> ObterFrequenciasExecucao();
    }
}
