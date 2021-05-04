using FileManager.Core.Application.Entities;
using FileManager.Core.Application.Persistence;
using FileManager.Infra.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Infra.Persistence
{
    public class CamposRepository : Repository<Campo>, ICamposRepository
    {
        public CamposRepository(MeuDbContext context) : base(context) { }
    }
}
