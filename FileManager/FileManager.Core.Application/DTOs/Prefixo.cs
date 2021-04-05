using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.DTOs
{
    public class Prefixo : Entity
    {
        public string Descricao { get; set; }

        public Arquivo Arquivo { get; set; }
    }
}
