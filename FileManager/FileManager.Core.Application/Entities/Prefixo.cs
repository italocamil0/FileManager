using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.Entities
{
    public class Prefixo : Entity
    {
        public string Descricao { get; set; }

        public IEnumerable<Arquivo> Arquivo { get; set; }
    }
}
