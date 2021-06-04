using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Service
{
    public class FrequenciaExecucaoService : IFrequenciaExecucaoPort
    {

        private readonly IFrequenciaExecucaoRepository _frequenciaExecucaoRepository;
        public FrequenciaExecucaoService(IFrequenciaExecucaoRepository frequenciaExecucaoRepository)
        {
            _frequenciaExecucaoRepository = frequenciaExecucaoRepository;
        }

        public Task<IEnumerable<FrequenciaExecucao>> Buscar(Expression<Func<FrequenciaExecucao, bool>> predicate)
        {
            return _frequenciaExecucaoRepository.Buscar(predicate);
        }

        public Task<FrequenciaExecucao> ObterPorId(Guid id)
        {
            return _frequenciaExecucaoRepository.ObterPorId(id);
        }

        public Task<List<FrequenciaExecucao>> ObterTodos()
        {
            return _frequenciaExecucaoRepository.ObterTodos();
        }
    }
}
