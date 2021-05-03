using FileManager.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Core.Application.Persistence
{
    public interface IArquivosRepository : IRepository<Arquivo>
    {
        Task<IEnumerable<Arquivo>> ObterArquivosFrequenciasPrefixos();
    }
}
