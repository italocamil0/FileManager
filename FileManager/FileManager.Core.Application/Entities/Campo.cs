using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.Entities
{
    public class Campo : Entity
    {
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }

        /* EF Relations */
        public Arquivo Arquivo { get; set; }
    }
}
