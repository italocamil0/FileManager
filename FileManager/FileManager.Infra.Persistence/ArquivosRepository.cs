using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Infra.Persistence
{
    public class ArquivosRepository : Repository<Arquivo>, IArquivosRepository
    {
        public ArquivosRepository(MeuDbContext contexto) : base(contexto)
        {
        }

        public async Task<IEnumerable<Arquivo>> ObterArquivosFrequenciasPrefixos()
        {
            return await Db.Arquivos.AsNoTracking().Include(p => p.Prefixo).Include(d => d.FrequenciaExecucao)
                .OrderBy(p => p.Tabela).ToListAsync();
        }


        //public async Task<DetalheArquivoFrequencia> ObterDetalheArquivoFrequencia(Guid idArquivo)
        //{
        //    return await Db.DetalheArquivoFrequencia.FirstOrDefaultAsync(x => x.ArquivoId == idArquivo);
        //}


        //public void SalvarDetalheArquivoFrequencia(DetalheArquivoFrequencia detalheArquivoFrequencia)
        //{
        //    Db.DetalheArquivoFrequencia.Update(detalheArquivoFrequencia);           
        //}

    }
}
