using FileManager.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Port
{
    public interface ICamposPort
    {
        Task Remover(Guid id);
        Task<IEnumerable<Campo>> Buscar(Expression<Func<Campo, bool>> predicate);
    }
}
