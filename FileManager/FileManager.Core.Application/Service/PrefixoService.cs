using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Core.Application.Port;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Service
{
    public class PrefixoService : IPrefixoPort
    {
        private readonly IPrefixoRepository _prefixoRepository;
        public PrefixoService(IPrefixoRepository prefixoRepository)
        {
            _prefixoRepository = prefixoRepository;
        }

        public Task<IEnumerable<Prefixo>> Buscar(Expression<Func<Prefixo, bool>> predicate)
        {
            return _prefixoRepository.Buscar(predicate);
        }

        public Task<List<Prefixo>> ObterTodos()
        {
            return _prefixoRepository.ObterTodos();
        }
    }
}
