using FileManager.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Port
{
    public interface IFrequenciaExecucaoPort
    {
        Task<FrequenciaExecucao> ObterPorId(Guid id);
        Task<List<FrequenciaExecucao>> ObterTodos();
        Task<IEnumerable<FrequenciaExecucao>> Buscar(Expression<Func<FrequenciaExecucao, bool>> predicate);
    }
}
