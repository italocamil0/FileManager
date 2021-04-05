using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Core.Application.DTOs
{
    public class FrequenciaExecucao : Entity
    {
        public string Frequencia { get; set; }

        public Arquivo Arquivo { get; set; }
    }
}
