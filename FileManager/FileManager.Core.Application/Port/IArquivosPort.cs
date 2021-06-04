using FileManager.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Port
{
    public interface IArquivosPort
    {
        Task Adicionar(Arquivo entity);
        Task<Arquivo> ObterPorId(Guid id);
        Task<List<Arquivo>> ObterTodos();
        Task Atualizar(Arquivo entity);
        Task Remover(Guid id);
        Task<IEnumerable<Arquivo>> Buscar(Expression<Func<Arquivo, bool>> predicate);
        Task<IEnumerable<Arquivo>> ObterArquivosFrequenciasPrefixos();
    }
}
