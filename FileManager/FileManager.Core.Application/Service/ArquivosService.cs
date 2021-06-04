using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Service
{
    public class ArquivosService : IArquivosPort
    {
        private readonly IArquivosRepository _arquivosRepository;


        public ArquivosService(IArquivosRepository arquivosRepository)
        {
            _arquivosRepository = arquivosRepository;
        }

        public Task Adicionar(Arquivo arquivo)
        {
            return _arquivosRepository.Adicionar(arquivo);
        }

        public Task Atualizar(Arquivo entity)
        {
            return _arquivosRepository.Atualizar(entity);
        }

        public Task<IEnumerable<Arquivo>> Buscar(Expression<Func<Arquivo, bool>> predicate)
        {
            return _arquivosRepository.Buscar(predicate);
        }

        public Task<IEnumerable<Arquivo>> ObterArquivosFrequenciasPrefixos()
        {
            return _arquivosRepository.ObterArquivosFrequenciasPrefixos();
        }

        public Task<Arquivo> ObterPorId(Guid id)
        {
            return _arquivosRepository.ObterPorId(id);
        }

        public Task<List<Arquivo>> ObterTodos()
        {
            return _arquivosRepository.ObterTodos();
        }

        public Task Remover(Guid id)
        {
            return _arquivosRepository.Remover(id);
        }
    }
}
