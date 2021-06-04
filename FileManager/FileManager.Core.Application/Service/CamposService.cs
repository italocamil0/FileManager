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
    public class CamposService : ICamposPort
    {
        private readonly ICamposRepository _camposRepository;
        public CamposService(ICamposRepository camposRepository)
        {
            _camposRepository = camposRepository;
        }

        public Task<IEnumerable<Campo>> Buscar(Expression<Func<Campo, bool>> predicate)
        {
            return _camposRepository.Buscar(predicate);
        }

        public Task Remover(Guid id)
        {
            return _camposRepository.Remover(id);
        }
    }
}
