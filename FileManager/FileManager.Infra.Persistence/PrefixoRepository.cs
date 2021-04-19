using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManager.Infra.Persistence
{
    public class PrefixoRepository : Repository<Prefixo>, IPrefixoRepository
    {
        public PrefixoRepository(MeuDbContext context) : base(context) { }



        public async Task<IEnumerable<Prefixo>> ObterPrefixos()
        {
            return await Db.Prefixos.AsNoTracking().ToListAsync();
        }
    }
}
