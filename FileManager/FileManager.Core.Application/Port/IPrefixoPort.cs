using FileManager.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Port
{
    public interface IPrefixoPort
    {
        Task<IEnumerable<Prefixo>> Buscar(Expression<Func<Prefixo, bool>> predicate);
        Task<List<Prefixo>> ObterTodos();
    }
}
